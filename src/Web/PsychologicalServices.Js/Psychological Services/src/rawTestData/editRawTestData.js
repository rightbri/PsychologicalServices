import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';

@inject(Router, DataRepository, Config, Context, Notifier, Scroller)
export class EditRawTestData {

    constructor(router, dataRepository, config, context, notifier, scroller) {
        this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.notifier = notifier;
		this.scroller = scroller;
		
		this.userMatcher = (a, b) => a && b && a.userId === b.userId;
		this.referralSourceMatcher = (a, b) => a && b && a.referralSourceId === b.referralSourceId;
		this.rawTestDataStatusMatcher = (a, b) => a && b && a.rawTestDataStatusId === b.rawTestDataStatusId;

		this.searchClaimant = null;
        this.searchCompanyId = null;

        this.saveDisabled = false;
		this.validationErrors = null;
    }
    
    activate(params) {
        var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
        return this.context.getUser()
			.then(user => {
				this.user = user;
				
				if (id) {
                    return this.dataRepository.getRawTestData(id).then(data => {
                        this.rawTestData = data;

                        this.rawTestData.note = this.rawTestData.note || { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user };

                        return this.getData().then(() => {
							this.searchClaimant = this.rawTestData.claimant;
			
							this.scroller.scrollTo(0);
                        });
                    });
                }
                else {
                    //new rawTestData
                    this.rawTestData = {
                        isAdd: true,
						note: { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user },
						company: this.user.company,
                    };

                    return this.getData().then(() => {
                        this.scroller.scrollTo(0);
                    });
                }
            });
    }

    getData() {
        return Promise.all([
			this.dataRepository.getReferralSources().then(data => this.referralSources = data),
			
            this.dataRepository.getPsychologists(this.user.company.companyId).then(data => this.psychologists = data),

			this.dataRepository.getRawTestDataStatuses().then(data => this.rawTestDataStatuses = data)
        ]);
    }

    save() {
		this.saveDisabled = true;
		
		var isNew = this.rawTestData.rawTestDataId === 0;
		
		this.dataRepository.saveRawTestData(this.rawTestData)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
					
                if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.rawTestData = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editRawTestData',
							{ 'id': this.rawTestData.rawTestDataId },
							{ 'trigger': false, replace: true }
						);
						
						this.editType = 'Edit';
					}
					
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				
				this.saveDisabled = false;
            })
			.catch(err => {
				this.saveDisabled = false;
			});
	}
	
	back() {
		this.router.navigateBack();
	}
    
    claimantSelected(e) {
		this.rawTestData.claimant = e.detail.claimant;
	}
}