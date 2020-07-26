import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class ReferralTypeStatistics {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;

        this.startAppointmentTime = null;
        this.endAppointmentTime = null;

        this.visibleTab = 0;
    }

    activate() {
        return this.context.getUser().then(user => this.user = user);
    }

    search() {
        this.dataRepository.searchReferralTypeData({
            'companyId': this.user.company.companyId,
            'startAppointmentTime': this.startAppointmentTime,
            'endAppointmentTime': this.endAppointmentTime
        }).then(data => {
            this.referralTypeData = data;

            this.byReferralTypeByMonth = this.referralTypeData.reduce(function(accumulator, currentValue) {
                let referralTypeMonth = accumulator.find(element =>
                    element.referralType === currentValue.referralType &&
                    element.year === currentValue.year &&
                    element.month === currentValue.month
                );
                
                if (referralTypeMonth === undefined) {
                    referralTypeMonth = {
                        'referralType': currentValue.referralType,
                        'year': currentValue.year,
                        'month': currentValue.month,
                        'monthName': this.config.months[currentValue.month],
                        'assessmentCount': 0,
                        'defenseCount': 0,
                        'plaintiffCount': 0
                    };

                    accumulator.push(referralTypeMonth);
                }

                referralTypeMonth.assessmentCount += 1;
                referralTypeMonth.defenseCount += currentValue.isDefense ? 1 : 0;
                referralTypeMonth.plaintiffCount += currentValue.isPlaintiff ? 1 : 0;

                return accumulator;
            }.bind(this), []);

            this.byReferralType = this.referralTypeData.reduce(function(accumulator, currentValue) {
                let referralType = accumulator.find(element => element.referralType === currentValue.referralType);

                if (referralType === undefined) {
                    referralType = {
                        'referralType': currentValue.referralType,
                        'assessmentCount': 0,
                        'defenseCount': 0,
                        'plaintiffCount': 0
                    };

                    accumulator.push(referralType);
                }

                referralType.assessmentCount += 1;
                referralType.defenseCount += currentValue.isDefense ? 1 : 0;
                referralType.plaintiffCount += currentValue.isPlaintiff ? 1 : 0;

                return accumulator;
            }, []);

            this.byMonth = this.byReferralTypeByMonth.reduce(function(accumulator, currentValue) {
                let month = accumulator.find(element =>
                    element.year === currentValue.year &&
                    element.month === currentValue.month
                );

                if (month === undefined) {
                    month = {
                        'year': currentValue.year,
                        'month': currentValue.month,
                        'monthName': this.config.months[currentValue.month],
                        'assessmentCount': 0,
                        'defenseCount': 0,
                        'plaintiffCount': 0
                    };

                    accumulator.push(month);
                }

                month.assessmentCount += currentValue.assessmentCount;
                month.defenseCount += currentValue.defenseCount;
                month.plaintiffCount += currentValue.plaintiffCount;
                
                return accumulator;
            }.bind(this), []);

            this.total = this.byMonth.reduce(function(accumulator, currentValue) {
                accumulator.assessmentCount += currentValue.assessmentCount;
                accumulator.defenseCount += currentValue.defenseCount;
                accumulator.plaintiffCount += currentValue.plaintiffCount;
                
                return accumulator;
            }, {
                'assessmentCount': 0,
                'defenseCount': 0,
                'plaintiffCount': 0
            });

            this.total.percentDefense = this.total.defenseCount / this.total.assessmentCount;
            this.total.percentPlaintiff = this.total.plaintiffCount / this.total.assessmentCount;


            for (let i = 0; i < this.byReferralTypeByMonth.length; i++) {
                let x = this.byReferralTypeByMonth[i];

                let monthTotal = this.byMonth.find(element =>
                    element.year === x.year &&
                    element.month === x.month
                );

                x.percentAssessments = x.assessmentCount / monthTotal.assessmentCount;
                x.percentDefense = x.defenseCount / monthTotal.defenseCount;
                x.percentPlaintiff = x.plaintiffCount / monthTotal.plaintiffCount;
            }

            for (let i = 0; i < this.byReferralType.length; i++) {
                let x = this.byReferralType[i];

                x.percentAssessments = x.assessmentCount / this.total.assessmentCount;
                x.percentDefense = x.defenseCount / this.total.defenseCount;
                x.percentPlaintiff = x.plaintiffCount / this.total.plaintiffCount;
            }

            for (let i = 0; i < this.byMonth.length; i++) {
                let x = this.byMonth[i];

                x.percentAssessments = x.assessmentCount / this.total.assessmentCount;
                x.percentDefense = x.defenseCount / this.total.defenseCount;
                x.percentPlaintiff = x.plaintiffCount / this.total.plaintiffCount;
            }
        });
    }
    
    showTab(index) {
        this.visibleTab = index;
    }
}