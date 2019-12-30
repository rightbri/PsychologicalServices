import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class CancellationStatistics {

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
        this.dataRepository.searchCancellationData({
            'companyId': this.user.company.companyId,
            'months': this.searchMonths
        }).then(data => {
            this.cancellationData = data;

            this.referralSourcesByMonth = this.cancellationData.reduce(function(accumulator, currentValue) {
                let referralSourceMonth = accumulator.find(element =>
                    element.referralSource === currentValue.referralSource &&
                    element.year === currentValue.year &&
                    element.month === currentValue.month
                );
                
                if (referralSourceMonth === undefined) {
                    referralSourceMonth = {
                        'referralSource': currentValue.referralSource,
                        'year': currentValue.year,
                        'month': currentValue.month,
                        'monthName': this.config.months[currentValue.month],
                        'appointmentCount': 0,
                        'billableCount': 0,
                        'canceledCount': 0,
                        'lateCanceledCount': 0
                    };

                    accumulator.push(referralSourceMonth);
                }

                referralSourceMonth.appointmentCount += currentValue.appointmentCount;
                referralSourceMonth.billableCount += currentValue.billableCount;
                referralSourceMonth.canceledCount += currentValue.canceledCount;
                referralSourceMonth.lateCanceledCount += currentValue.lateCanceledCount;

                return accumulator;
            }.bind(this), []);

            this.referralSources = this.referralSourcesByMonth.reduce(function(accumulator, currentValue) {
                let referralSource = accumulator.find(element => element.referralSource === currentValue.referralSource);
                
                if (referralSource === undefined) {
                    referralSource = {
                        'referralSource': currentValue.referralSource,
                        'appointmentCount': 0,
                        'billableCount': 0,
                        'canceledCount': 0,
                        'lateCanceledCount': 0
                    };

                    accumulator.push(referralSource);
                }

                referralSource.appointmentCount += currentValue.appointmentCount;
                referralSource.billableCount += currentValue.billableCount;
                referralSource.canceledCount += currentValue.canceledCount;
                referralSource.lateCanceledCount += currentValue.lateCanceledCount;

                return accumulator;
            }, []);

            this.insuranceCompanies = this.cancellationData.reduce(function(accumulator, currentValue) {
                let insuranceCompany = accumulator.find(element =>
                    element.insuranceCompany === currentValue.insuranceCompany
                );
                
                if (insuranceCompany === undefined) {
                    insuranceCompany = {
                        'insuranceCompany': currentValue.insuranceCompany,
                        'appointmentCount': 0,
                        'billableCount': 0,
                        'canceledCount': 0,
                        'lateCanceledCount': 0
                    };

                    accumulator.push(insuranceCompany);
                }

                insuranceCompany.appointmentCount += currentValue.appointmentCount;
                insuranceCompany.billableCount += currentValue.billableCount;
                insuranceCompany.canceledCount += currentValue.canceledCount;
                insuranceCompany.lateCanceledCount += currentValue.lateCanceledCount;

                return accumulator;
            }.bind(this), []);

            this.summary = this.referralSources.reduce(function(accumulator, currentValue) {
                accumulator.appointmentCount += currentValue.appointmentCount;
                accumulator.billableCount += currentValue.billableCount;
                accumulator.canceledCount += currentValue.canceledCount;
                accumulator.lateCanceledCount += currentValue.lateCanceledCount;

                return accumulator;
            }, {
                'appointmentCount': 0,
                'billableCount': 0,
                'canceledCount': 0,
                'lateCanceledCount': 0
            });

            this.summary.percentBillable = this.summary.billableCount / this.summary.appointmentCount;
            this.summary.percentCanceled = this.summary.canceledCount / this.summary.appointmentCount;
            this.summary.percentLateCanceled = this.summary.lateCanceledCount / this.summary.appointmentCount;

            for (let i = 0; i < this.referralSources.length; i++) {
                let rs = this.referralSources[i];

                rs.percentBillable = rs.billableCount / rs.appointmentCount;
                rs.percentCanceled = rs.canceledCount / rs.appointmentCount;
                rs.percentLateCanceled = rs.lateCanceledCount / rs.appointmentCount;
            }

            for (let i = 0; i < this.referralSourcesByMonth.length; i++) {
                let rsm = this.referralSourcesByMonth[i];

                rsm.percentBillable = rsm.billableCount / rsm.appointmentCount;
                rsm.percentCanceled = rsm.canceledCount / rsm.appointmentCount;
                rsm.percentLateCanceled = rsm.lateCanceledCount / rsm.appointmentCount;
            }

            for (let i = 0; i < this.insuranceCompanies.length; i++) {
                let ic = this.insuranceCompanies[i];

                ic.percentBillable = ic.billableCount / ic.appointmentCount;
                ic.percentCanceled = ic.canceledCount / ic.appointmentCount;
                ic.percentLateCanceled = ic.lateCanceledCount / ic.appointmentCount;
            }
        });
    }
    
    showTab(index) {
        this.visibleTab = index;
    }
}