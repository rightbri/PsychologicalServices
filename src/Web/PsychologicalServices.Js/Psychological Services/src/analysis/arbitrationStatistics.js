import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class ArbitrationStatistics {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;

        this.searchMonths = null;
        this.visibleTab = 0;
    }

    activate() {
        return this.context.getUser().then(user => this.user = user);
    }

    search() {
        this.dataRepository.searchArbitrationData({
            'companyId': this.user.company.companyId,
            'months': this.searchMonths
        }).then(data => {
            this.arbitrationData = data;

            this.arbitrationsByReferralSource = this.arbitrationData.reduce(function(accumulator, currentValue) {
                let referralSource = accumulator.find(element =>
                    element.referralSourceId === currentValue.referralSourceId
                );

                if (referralSource === undefined) {
                    referralSource = {
                        'referralSourceId': currentValue.referralSourceId,
                        'referralSource': currentValue.referralSource,
                        'arbitrationIds': [],
                        'arbitrationCount': 0
                    };

                    accumulator.push(referralSource);
                }

                let arbitrationCounted = referralSource.arbitrationIds.some(id => id === currentValue.arbitrationId);

                if (!arbitrationCounted) {
                    referralSource.arbitrationIds.push(currentValue.arbitrationId);
                    referralSource.arbitrationCount += 1;
                }

                return accumulator;
            }.bind(this), []);

            this.arbitrationsByReferralType = this.arbitrationData.reduce(function(accumulator, currentValue) {
                let referralType = accumulator.find(element =>
                    element.referralTypeId === currentValue.issueInDisputeId
                );

                if (referralType === undefined) {
                    referralType = {
                        'referralTypeId': currentValue.issueInDisputeId,
                        'referralType': currentValue.issueInDispute,
                        'arbitrationCount': 0
                    };

                    accumulator.push(referralType);
                }

                referralType.arbitrationCount += 1;

                return accumulator;
            }.bind(this), []);

            this.arbitrationsByLawyer = this.arbitrationData.reduce(function(accumulator, currentValue) {
                let lawyer = accumulator.find(element =>
                    element.lawyerId === currentValue.lawyerId
                );

                if (lawyer === undefined) {
                    lawyer = {
                        'lawyerId': currentValue.lawyerId,
                        'lawyer': currentValue.lawyer,
                        'arbitrationIds': [],
                        'arbitrationCount': 0
                    };

                    accumulator.push(lawyer);
                }

                let arbitrationCounted = lawyer.arbitrationIds.some(id => id === currentValue.arbitrationId);

                if (!arbitrationCounted) {
                    lawyer.arbitrationIds.push(currentValue.arbitrationId);
                    lawyer.arbitrationCount += 1;
                }

                return accumulator;
            }.bind(this), []);

            this.arbitrationsTotal = this.arbitrationData.reduce(function(accumulator, currentValue) {
                let arbitration = accumulator.find(element =>
                    element.arbitrationId === currentValue.arbitrationId
                );

                if (arbitration === undefined) {
                    arbitration = {
                        'arbitrationId': currentValue.arbitrationId,
                        'arbitrationCount': 1
                    };

                    accumulator.push(arbitration);
                }

                return accumulator;
            }.bind(this), []).length;

            for (let i = 0; i < this.arbitrationsByReferralSource.length; i++) {
                let x = this.arbitrationsByReferralSource[i];

                x.percentArbitrations = x.arbitrationCount / this.arbitrationsTotal;
            }

            for (let i = 0; i < this.arbitrationsByReferralType.length; i++) {
                let x = this.arbitrationsByReferralType[i];

                x.percentArbitrations = x.arbitrationCount / this.arbitrationsTotal;
            }

            for (let i = 0; i < this.arbitrationsByLawyer.length; i++) {
                let x = this.arbitrationsByLawyer[i];

                x.percentArbitrations = x.arbitrationCount / this.arbitrationsTotal;
            }
        });
    }
    
    showTab(index) {
        this.visibleTab = index;
    }
}