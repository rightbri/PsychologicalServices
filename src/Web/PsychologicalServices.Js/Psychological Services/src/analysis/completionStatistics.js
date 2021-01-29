import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class CompletionStatistics {

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
        this.dataRepository.searchCompletionData({
            'companyId': this.user.company.companyId,
            'startAppointmentTime': this.startAppointmentTime,
            'endAppointmentTime': this.endAppointmentTime
        }).then(data => {
            this.completionData = data;

            this.readerSummary = this.completionData.reduce(function(accumulator, currentValue) {
                let readerValue = accumulator.find(element => element.hasReader === currentValue.hasReader);

                if (readerValue === undefined) {
                    readerValue = {
                        'hasReader': currentValue.hasReader,
                        'assessmentCount': 0,
                        'incompleteCount': 0,
                        'completeCount': 0
                    };

                    accumulator.push(readerValue);
                }

                readerValue.assessmentCount += 1;
                readerValue.incompleteCount += currentValue.incompleteCount;
                readerValue.completeCount += currentValue.completeCount;

                return accumulator;
            }, []);
            
            this.translatorSummary = this.completionData.reduce(function(accumulator, currentValue) {
                let translatorValue = accumulator.find(element => element.hasTranslator === currentValue.hasTranslator);

                if (translatorValue === undefined) {
                    translatorValue = {
                        'hasTranslator': currentValue.hasTranslator,
                        'assessmentCount': 0,
                        'incompleteCount': 0,
                        'completeCount': 0
                    };

                    accumulator.push(translatorValue);
                }

                translatorValue.assessmentCount += 1;
                translatorValue.incompleteCount += currentValue.incompleteCount;
                translatorValue.completeCount += currentValue.completeCount;

                return accumulator;
            }, []);

            this.psychiatristSummary = this.completionData.reduce(function(accumulator, currentValue) {
                let psychiatristValue = accumulator.find(element => element.hasPsychiatrist === currentValue.hasPsychiatrist);

                if (psychiatristValue === undefined) {
                    psychiatristValue = {
                        'hasPsychiatrist': currentValue.hasPsychiatrist,
                        'assessmentCount': 0,
                        'incompleteCount': 0,
                        'completeCount': 0
                    };

                    accumulator.push(psychiatristValue);
                }

                psychiatristValue.assessmentCount += 1;
                psychiatristValue.incompleteCount += currentValue.incompleteCount;
                psychiatristValue.completeCount += currentValue.completeCount;

                return accumulator;
            }, []);

            this.femaleClaimantSummary = this.completionData.reduce(function(accumulator, currentValue) {
                let femaleClaimantValue = accumulator.find(element => element.isFemaleClaimant === currentValue.isFemaleClaimant);

                if (femaleClaimantValue === undefined) {
                    femaleClaimantValue = {
                        'isFemaleClaimant': currentValue.isFemaleClaimant,
                        'assessmentCount': 0,
                        'incompleteCount': 0,
                        'completeCount': 0
                    };

                    accumulator.push(femaleClaimantValue);
                }

                femaleClaimantValue.assessmentCount += 1;
                femaleClaimantValue.incompleteCount += currentValue.incompleteCount;
                femaleClaimantValue.completeCount += currentValue.completeCount;

                return accumulator;
            }, []);

            this.psychometristsByMonth = this.completionData.reduce(function(accumulator, currentValue) {
                let psychometristMonth = accumulator.find(element =>
                    element.psychometrist === currentValue.psychometrist &&
                    element.year === currentValue.year &&
                    element.month === currentValue.month
                );
                
                if (psychometristMonth === undefined) {
                    psychometristMonth = {
                        'psychometrist': currentValue.psychometrist,
                        'year': currentValue.year,
                        'month': currentValue.month,
                        'monthName': this.config.months[currentValue.month],
                        'assessmentCount': 0,
                        'incompleteCount': 0,
                        'completeCount': 0
                    };

                    accumulator.push(psychometristMonth);
                }

                psychometristMonth.assessmentCount += 1;
                psychometristMonth.incompleteCount += currentValue.incompleteCount;
                psychometristMonth.completeCount += currentValue.completeCount;

                return accumulator;
            }.bind(this), []);

            this.psychometrists = this.psychometristsByMonth.reduce(function(accumulator, currentValue) {
                let psychometrist = accumulator.find(element => element.psychometrist === currentValue.psychometrist);
                
                if (psychometrist === undefined) {
                    psychometrist = {
                        'psychometrist': currentValue.psychometrist,
                        'assessmentCount': 0,
                        'incompleteCount': 0,
                        'completeCount': 0
                    };

                    accumulator.push(psychometrist);
                }

                psychometrist.assessmentCount += currentValue.assessmentCount;
                psychometrist.incompleteCount += currentValue.incompleteCount;
                psychometrist.completeCount += currentValue.completeCount;

                return accumulator;
            }, []);

            this.summary = this.psychometrists.reduce(function(accumulator, currentValue) {
                accumulator.assessmentCount += currentValue.assessmentCount;
                accumulator.incompleteCount += currentValue.incompleteCount;
                accumulator.completeCount += currentValue.completeCount;

                return accumulator;
            }, {
                'assessmentCount': 0,
                'incompleteCount': 0,
                'completeCount': 0
            });

            this.summary.percentIncomplete = this.summary.incompleteCount / this.summary.assessmentCount;
            this.summary.percentComplete = this.summary.completeCount / this.summary.assessmentCount; 

            for (let i = 0; i < this.readerSummary.length; i++) {
                let r = this.readerSummary[i];

                r.percentIncomplete = r.incompleteCount / r.assessmentCount;
                r.percentComplete = r.completeCount / r.assessmentCount;
            }

            for (let i = 0; i < this.translatorSummary.length; i++) {
                let t = this.translatorSummary[i];

                t.percentIncomplete = t.incompleteCount / t.assessmentCount;
                t.percentComplete = t.completeCount / t.assessmentCount;
            }

            for (let i = 0; i < this.psychiatristSummary.length; i++) {
                let p = this.psychiatristSummary[i];

                p.percentIncomplete = p.incompleteCount / p.assessmentCount;
                p.percentComplete = p.completeCount / p.assessmentCount;
            }
            
            for (let i = 0; i < this.femaleClaimantSummary.length; i++) {
                let f = this.femaleClaimantSummary[i];

                f.percentIncomplete = f.incompleteCount / f.assessmentCount;
                f.percentComplete = f.completeCount / f.assessmentCount;
            }
            
            for (let i = 0; i < this.psychometrists.length; i++) {
                let psy = this.psychometrists[i];

                psy.percentIncomplete = psy.incompleteCount / psy.assessmentCount;
                psy.percentComplete = psy.completeCount / psy.assessmentCount;
            }

            for (let i = 0; i < this.psychometristsByMonth.length; i++) {
                let psy = this.psychometristsByMonth[i];

                psy.percentIncomplete = psy.incompleteCount / psy.assessmentCount;
                psy.percentComplete = psy.completeCount / psy.assessmentCount;
            }

        });
        
    }
    
    showTab(index) {
        this.visibleTab = index;
    }
}