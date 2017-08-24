import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';

@inject(DataRepository, Context)
export class BookingStatistics {

    constructor(dataRepository, context) {
        this.dataRepository = dataRepository;
        this.context = context;

    }

    activate() {
        return this.context.getUser().then(user => this.user = user);
    }

    search() {
        this.dataRepository.searchBookingData({
            'companyId': this.user.company.companyId,
            'months': this.searchMonths
        }).then(data => {
            this.bookingData = data;
/*
% bookings by Referral Source (over last X months)
% bookings by Referral Source by Month

% bookings by P vs anything else

% bookings by Referral Source by P vs anything else
*/

            this.bookingsByReferralSourceByMonth = this.bookingData.reduce(function(accumulator, currentValue) {
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
                        'bookingCount': 0
                    };

                    accumulator.push(referralSourceMonth);
                }

                referralSourceMonth.bookingCount += 1;

                return accumulator;
            }, []);

            this.bookingsByReferralSource = this.bookingsByReferralSourceByMonth.reduce(function(accumulator, currentValue) {
                let referralSource = accumulator.find(element => element.referralSource === currentValue.referralSource);

                if (referralSource === undefined) {
                    referralSource = {
                        'referralSource': currentValue.referralSource,
                        'bookingCount': 0
                    };

                    accumulator.push(referralSource);
                }

                referralSource.bookingCount += currentValue.bookingCount;
                
                return accumulator;
            }, []);

            this.bookingsByReferralSourceByIsPsychological = this.bookingData.reduce(function(accumulator, currentValue) {
                let referralSourcePsychological = accumulator.find(element =>
                    element.referralSource === currentValue.referralSource &&
                    element.isPsychological === currentValue.isPsychological
                );
                
                if (referralSourcePsychological === undefined) {
                    referralSourcePsychological = {
                        'referralSource': currentValue.referralSource,
                        'isPsychological': currentValue.isPsychological,
                        'bookingCount': 0
                    };

                    accumulator.push(referralSourcePsychological);
                }

                referralSourcePsychological.bookingCount += 1;

                return accumulator;
            }, []);

            this.bookingsByIsPsychological = this.bookingsByReferralSourceByIsPsychological.reduce(function(accumulator, currentValue) {
                let isPsychological = accumulator.find(element =>
                    element.isPsychological === currentValue.isPsychological
                );
                
                if (isPsychological === undefined) {
                    isPsychological = {
                        'isPsychological': currentValue.isPsychological,
                        'bookingCount': 0
                    };

                    accumulator.push(isPsychological);
                }

                isPsychological.bookingCount += currentValue.bookingCount;

                return accumulator;
            }, []);

            this.bookingsByReferralSourceByIsLargeFile = this.bookingData.reduce(function(accumulator, currentValue) {
                let referralSourceLargeFile = accumulator.find(element =>
                    element.referralSource === currentValue.referralSource &&
                    element.isLargeFile === currentValue.isLargeFile
                );
                
                if (referralSourceLargeFile === undefined) {
                    referralSourceLargeFile = {
                        'referralSource': currentValue.referralSource,
                        'isLargeFile': currentValue.isLargeFile,
                        'bookingCount': 0
                    };

                    accumulator.push(referralSourceLargeFile);
                }

                referralSourceLargeFile.bookingCount += 1;

                return accumulator;
            }, []);

            this.bookingsByMonth = this.bookingsByReferralSourceByMonth.reduce(function(accumulator, currentValue) {
                let month = accumulator.find(element =>
                    element.year === currentValue.year &&
                    element.month === currentValue.month
                );

                if (month === undefined) {
                    month = {
                        'year': currentValue.year,
                        'month': currentValue.month,
                        'bookingCount': 0
                    };

                    accumulator.push(month);
                }

                month.bookingCount += currentValue.bookingCount;
                
                return accumulator;
            }, []);

            this.bookingTotal = this.bookingsByIsPsychological.reduce(function(accumulator, currentValue) {
                return accumulator + currentValue.bookingCount;
            }, 0);

            for (let i = 0; i < this.bookingsByReferralSourceByMonth.length; i++) {
                let x = this.bookingsByReferralSourceByMonth[i];

                let monthTotal = this.bookingsByMonth.find(element =>
                    element.year === x.year &&
                    element.month === x.month
                );

                if (monthTotal === undefined) {
                    monthTotal = {
                        'year': x.year,
                        'month': x.month,
                        'bookingCount': 0
                    };
                }

                x.percentBookings = x.bookingCount / monthTotal.bookingCount;
            }

            for (let i = 0; i < this.bookingsByReferralSource.length; i++) {
                let x = this.bookingsByReferralSource[i];

                x.percentBookings = x.bookingCount / this.bookingTotal;
            }

            for (let i = 0; i < this.bookingsByReferralSourceByIsPsychological.length; i++) {
                let x = this.bookingsByReferralSourceByIsPsychological[i];

                let referralSourceTotal = this.bookingsByReferralSource.find(element =>
                    element.referralSource === x.referralSource
                );

                if (referralSourceTotal === undefined) {
                    referralSourceTotal = {
                        'referralSource': x.referralSource,
                        'bookingCount': 0
                    };
                }

                x.percentBookings = x.bookingCount / referralSourceTotal.bookingCount;
            }

            for (let i = 0; i < this.bookingsByReferralSourceByIsLargeFile.length; i++) {
                let x = this.bookingsByReferralSourceByIsLargeFile[i];

                let referralSourceTotal = this.bookingsByReferralSource.find(element =>
                    element.referralSource === x.referralSource
                );

                if (referralSourceTotal === undefined) {
                    referralSourceTotal = {
                        'referralSource': x.referralSource,
                        'bookingCount': 0
                    };
                }

                x.percentBookings = x.bookingCount / referralSourceTotal.bookingCount;
            }

            for (let i = 0; i < this.bookingsByIsPsychological.length; i++) {
                let x = this.bookingsByIsPsychological[i];

                x.percentBookings = x.bookingCount / this.bookingTotal;
            }

            for (let i = 0; i < this.bookingsByMonth.length; i++) {
                let x = this.bookingsByMonth[i];

                x.percentBookings = x.bookingCount / this.bookingTotal;
            }
        });
        
    }
}