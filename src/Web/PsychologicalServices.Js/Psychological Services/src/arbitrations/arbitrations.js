import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class Arbitrations {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;
    }

    activate() {
        return this.getData();
    }

    getData() {
        return this.context.getUser().then(user => {
            this.user = user;

            return Promise.all([
             
                this.dataRepository.searchContacts({
                    contactTypeIds: [this.config.contactTypes.defenseLawyer, this.config.contactTypes.defenseLawClerk]
                }).then(data => this.defenseLawyers = data),

                this.dataRepository.searchContacts({
                    contactTypeIds: [this.config.contactTypes.plaintiffLawyer, this.config.contactTypes.plaintiffLawClerk]
                }).then(data => this.plaintiffLawyers = data)

            ]);
        });
    }

    search() {

        this.dataRepository.searchArbitrations({
            'companyId': this.user.company.companyId,
            'claimantId': this.searchClaimant ? this.searchClaimant.claimantId : null
        }).then(data => {

            for (let arbitration of data) {
                
                for (let claim of arbitration.claims) {
                    arbitration.claimant = claim.claimant;
                    break;
                }
                
            }

            this.arbitrations = data;
        });

    }

    newArbitration() {
		this.dataRepository.getNewArbitration(this.assessment.assessmentId)
			.then(data => {
				data.isAdd = true;
				data.note = data.note || { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user };

				this.editArbitration(data);
			});
	}
	
	editArbitration(arbitration) {
		arbitration.note = arbitration.note || { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user };

		this.arbitrationEditModel = {
			'arbitration': arbitration,
            'defenseLawyers': this.defenseLawyers,
            'plaintiffLawyers': this.plaintiffLawyers
		};
	}
	
	arbitrationEdited(e) {
		let arbitration = e.detail.arbitration;
		
		if (arbitration.isAdd) {
            delete arbitration['isAdd'];
        }
        
        this.dataRepository.saveArbitration(arbitration)
            .then(data => {

                this.arbitrationEditModel.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
                    ? data.validationResult.validationErrors
                    : null;
                    
                if (data.isSaved) {
                    this.arbitrationEditModel.arbitration = data.item;
                    //this.arbitrationEditModel = null;
                    
                    /*
                    if (isNew) {
                        this.router.navigateToRoute(
                            'editAssessment',
                            { 'id': this.assessment.assessmentId },
                            { 'trigger': false, replace: true }
                        );
                        
                        this.editType = 'Edit';
                    }
                    */

                    //this.notifier.info('Saved');
                }
                
                if (data.isError) {
                    alert(data.errorDetails);
                    //this.notifier.error(data.errorDetails);
                }
            });
	}
	
	arbitrationCanceled(e) {
		let arbitration = e.detail.arbitration;

		if (!arbitration.isAdd) {
			copyValues(arbitration, this.arbitrationEditModel.arbitration);
		}
		
		this.arbitrationEditModel = null;
	}

}