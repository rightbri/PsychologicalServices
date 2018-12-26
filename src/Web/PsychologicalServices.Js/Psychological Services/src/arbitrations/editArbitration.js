import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';

@inject(Router, DataRepository, Config, Context, Notifier, Scroller)
export class EditArbitration {

    constructor(router, dataRepository, config, context, notifier, scroller) {
        this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.notifier = notifier;
		this.scroller = scroller;
		
		this.userMatcher = (a, b) => a !== null && b !== null && a.userId === b.userId;
		this.contactMatcher = (a, b) => a !== null && b !== null && a.contactId === b.contactId;
		this.claimMatcher = (a, b) => a !== null && b !== null && a.claimId === b.claimId;
		this.arbitrationStatusMatcher = (a, b) => a !== null && b != null && a.arbitrationStatusId === b.arbitrationStatusId;

		this.searchClaimant = null;
        this.searchCompanyId = null;
        this.billToContacts = [];

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
                    return this.dataRepository.getArbitration(id).then(data => {
                        this.arbitration = data;

                        this.arbitration.note = this.arbitration.note || { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user };

                        return this.getData().then(() => {

							this.searchClaimant = this.arbitration.claimant;

								this.updateBillToContacts();
			
								this.scroller.scrollTo(0);
                        });
                    });
                }
                else {
                    //new arbitration
                    this.arbitration = {
                        isAdd: true,
                        note: { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user }
                    };

                    return this.getData().then(() => {

                        this.updateBillToContacts();

                        this.scroller.scrollTo(0);
                    });
                }
            });
    }

    getData() {
        return Promise.all([

            this.dataRepository.searchContacts({
                contactTypeIds: [this.config.contactTypes.defenseLawyer, this.config.contactTypes.defenseLawClerk]
            }).then(data => this.defenseLawyers = data),

            this.dataRepository.searchContacts({
                contactTypeIds: [this.config.contactTypes.plaintiffLawyer, this.config.contactTypes.plaintiffLawClerk]
            }).then(data => this.plaintiffLawyers = data),

            this.dataRepository.getPsychologists(this.user.company.companyId).then(data => this.psychologists = data),

			this.dataRepository.getArbitrationStatuses().then(data => this.arbitrationStatuses = data)
        ]);
    }

    save() {
		this.saveDisabled = true;
		
		var isNew = this.arbitration.arbitrationId === 0;
		
		this.dataRepository.saveArbitration(this.arbitration)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
					
                if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.arbitration = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editArbitration',
							{ 'id': this.arbitration.arbitrationId },
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
		this.arbitration.claimant = e.detail.claimant;
	}

	plaintiffLawyerChanged() {
		this.updateBillToContacts();
	}

	defenseLawyerChanged() {
		this.updateBillToContacts();
	}

	updateBillToContacts() {

		for (let i = 0; i < this.billToContacts.length; i++) {
			this.billToContacts.splice(i, 1);
		}

		if (this.arbitration.plaintiffLawyer) {
			this.billToContacts.push(this.arbitration.plaintiffLawyer);
		}

		if (this.arbitration.defenseLawyer) {
			this.billToContacts.push(this.arbitration.defenseLawyer);
		}
	}

}