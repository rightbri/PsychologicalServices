import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {DialogService} from 'aurelia-dialog';
import {SearchClaimant} from '../claimants/search-claimant';

@inject(DataRepository, Config, Context, DialogService)
export class Assessments {
	constructor(dataRepository, config, context, dialogService) {
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.dialogService = dialogService;
		
		this.referralSources = null;
		
		this.searchReferralSourceId = null;
		this.searchClaimant = null;
		this.searchCompanyId = null;
	}
	
	activate() {
		
		return this.getData();
	}
	
	getData() {
		return Promise.all([
			this.context.getUser().then(user => this.searchCompanyId = user.company.companyId).catch(err => {
				return;
			}), 
			this.dataRepository.getReferralSources().then(data => this.referralSources = data)
		]);
	}
	
	search() {
		return this.dataRepository.searchAssessments({
			referralSourceId: this.searchReferralSourceId,
			claimantId: this.searchClaimant ? this.searchClaimant.claimantId : null,
			companyId: this.searchCompanyId
		}).then(data => this.assessments = data);
	}
	
	chooseClaimant() {
		var original = JSON.parse(JSON.stringify(this.searchClaimant));
		
		return this.dialogService.open({viewModel: SearchClaimant, model: { addClaimantEnabled: false }})
			.then(result => {
				var source = original;

				if (!result.wasCancelled) {
					source = result.output;
				}
				
				this.searchClaimant = source;
				
				return { wasCancelled: result.wasCancelled, claimant: this.searchClaimant };
			});
	}
}
