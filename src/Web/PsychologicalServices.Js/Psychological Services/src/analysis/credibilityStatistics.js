import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class CredibilityStatistics {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;

        this.visibleTab = 0;
    }

    activate() {
        return this.context.getUser().then(user => {
            this.user = user;

            return this.search();
        });
    }

    search() {
        this.dataRepository.searchCredibilityData({
            'companyId': this.user.company.companyId
        }).then(data => {
            this.credibilityData = data;

            this.credibilitiesByAssessmentType = this.credibilityData.credibilityDetailData.reduce(function(accumulator, currentValue) {
                let assessmentType = accumulator.find(element =>
                    element.assessmentTypeId === currentValue.assessmentTypeId
                );
                
                if (assessmentType === undefined) {
                    assessmentType = {
                        'assessmentTypeId': currentValue.assessmentTypeId,
                        'assessmentType': currentValue.assessmentTypeName,
                        'neuroCredibilityTotal': 0,
                        'psychCredibilityTotal': 0,
                        'neuroCredibleCount': 0,
                        'neuroNotCredibleCount': 0,
                        'neuroQuestionableCount': 0,
                        'psychCredibleCount': 0,
                        'psychNotCredibleCount': 0,
                        'psychQuestionableCount': 0,
                        'diagnosisFoundTotal': 0,
                        'diagnosisFoundYesCount': 0,
                        'diagnosisFoundNoCount': 0,
                        'diagnosisFoundRuleOutCount': 0,
                        'issueInDisputeApprovedTotal': 0,
                        'issueInDisputeApprovedYes': 0,
                        'issueInDisputeApprovedNo': 0,
                        'issueInDisputeApprovedUnknown': 0
                    };

                    accumulator.push(assessmentType);
                }

                assessmentType.neuroCredibilityTotal += currentValue.countNeurocognitiveCredibility ? 1 : 0;
                assessmentType.psychCredibilityTotal += currentValue.countPsychologicalCredibility ? 1 : 0;
                assessmentType.neuroCredibleCount += currentValue.neurocognitiveCredibilityCredible ? 1 : 0;
                assessmentType.neuroNotCredibleCount += currentValue.neurocognitiveCredibilityNotCredible ? 1 : 0;
                assessmentType.neuroQuestionableCount += currentValue.neurocognitiveCredibilityQuestionable ? 1 : 0;
                assessmentType.psychCredibleCount += currentValue.psychologicalCredibilityCredible ? 1 : 0;
                assessmentType.psychNotCredibleCount += currentValue.psychologicalCredibilityNotCredible ? 1 : 0;
                assessmentType.psychQuestionableCount += currentValue.psychologicalCredibilityQuestionable ? 1 : 0;
                assessmentType.diagnosisFoundTotal += 1;
                assessmentType.diagnosisFoundYesCount += currentValue.diagnosisFoundYes ? 1 : 0;
                assessmentType.diagnosisFoundNoCount += currentValue.diagnosisFoundNo ? 1 : 0;
                assessmentType.diagnosisFoundRuleOutCount += currentValue.diagnosisFoundRuleOut ? 1 : 0;
                assessmentType.issueInDisputeApprovedTotal += 1;
                assessmentType.issueInDisputeApprovedYes += currentValue.psychologistFoundInFavorOfClaimantYes ? 1 : 0;
                assessmentType.issueInDisputeApprovedNo += currentValue.psychologistFoundInFavorOfClaimantNo ? 1 : 0;
                assessmentType.issueInDisputeApprovedUnknown += currentValue.psychologistFoundInFavorOfClaimantUnknown ? 1 : 0;

                return accumulator;
            }.bind(this), []);

            for (let i = 0; i < this.credibilitiesByAssessmentType.length; i++) {
                let x = this.credibilitiesByAssessmentType[i];

                x.percentNeuroCredible = x.neuroCredibleCount / x.neuroCredibilityTotal;
                x.percentNeuroNotCredible = x.neuroNotCredibleCount / x.neuroCredibilityTotal;
                x.percentNeuroQuestionable = x.neuroQuestionableCount / x.neuroCredibilityTotal;

                x.percentPsychCredible = x.psychCredibleCount / x.psychCredibilityTotal;
                x.percentPsychNotCredible = x.psychNotCredibleCount / x.psychCredibilityTotal;
                x.percentPsychQuestionable = x.psychQuestionableCount / x.psychCredibilityTotal;

                x.percentDiagnosisFoundYes = x.diagnosisFoundYesCount / x.diagnosisFoundTotal;
                x.percentDiagnosisFoundNo = x.diagnosisFoundNoCount / x.diagnosisFoundTotal;
                x.percentDiagnosisFoundRuleOut = x.diagnosisFoundRuleOutCount / x.diagnosisFoundTotal;

                x.percentIssueInDisputeApprovedYes = x.issueInDisputeApprovedYes / x.issueInDisputeApprovedTotal;
                x.percentIssueInDisputeApprovedNo = x.issueInDisputeApprovedNo / x.issueInDisputeApprovedTotal;
                x.percentIssueInDisputeApprovedUnknown = x.issueInDisputeApprovedUnknown / x.issueInDisputeApprovedTotal;
            }

            this.credibilityTotal = {
                'neuroCredibilityTotal': 0,
                'psychCredibilityTotal': 0,
                'neuroCredibleCount': 0,
                'neuroNotCredibleCount': 0,
                'neuroQuestionableCount': 0,
                'psychCredibleCount': 0,
                'psychNotCredibleCount': 0,
                'psychQuestionableCount': 0,
                'diagnosisFoundTotal': 0,
                'diagnosisFoundYesCount': 0,
                'diagnosisFoundNoCount': 0,
                'diagnosisFoundRuleOutCount': 0,
                'issueInDisputeApprovedTotal': 0,
                'issueInDisputeApprovedYes': 0,
                'issueInDisputeApprovedNo': 0,
                'issueInDisputeApprovedUnknown': 0
            };
            
            for (let i = 0; i < this.credibilityData.credibilityDetailData.length; i++) {
                let item = this.credibilityData.credibilityDetailData[i];

                this.credibilityTotal.neuroCredibilityTotal += item.countNeurocognitiveCredibility ? 1 : 0;
                this.credibilityTotal.psychCredibilityTotal += item.countPsychologicalCredibility ? 1 : 0;
                this.credibilityTotal.neuroCredibleCount += item.neurocognitiveCredibilityCredible ? 1 : 0;
                this.credibilityTotal.neuroNotCredibleCount += item.neurocognitiveCredibilityNotCredible ? 1 : 0;
                this.credibilityTotal.neuroQuestionableCount += item.neurocognitiveCredibilityQuestionable ? 1 : 0;
                this.credibilityTotal.psychCredibleCount += item.psychologicalCredibilityCredible ? 1 : 0;
                this.credibilityTotal.psychNotCredibleCount += item.psychologicalCredibilityNotCredible ? 1 : 0;
                this.credibilityTotal.psychQuestionableCount += item.psychologicalCredibilityQuestionable ? 1 : 0;
                this.credibilityTotal.diagnosisFoundTotal += 1;
                this.credibilityTotal.diagnosisFoundYesCount += item.diagnosisFoundYes ? 1 : 0;
                this.credibilityTotal.diagnosisFoundNoCount += item.diagnosisFoundNo ? 1 : 0;
                this.credibilityTotal.diagnosisFoundRuleOutCount += item.diagnosisFoundRuleOut ? 1 : 0;
                this.credibilityTotal.issueInDisputeApprovedTotal += 1;
                this.credibilityTotal.issueInDisputeApprovedYes += item.psychologistFoundInFavorOfClaimantYes ? 1 : 0;
                this.credibilityTotal.issueInDisputeApprovedNo += item.psychologistFoundInFavorOfClaimantNo ? 1 : 0;
                this.credibilityTotal.issueInDisputeApprovedUnknown += item.psychologistFoundInFavorOfClaimantUnknown ? 1 : 0;
            }

            let x = this.credibilityTotal;

            x.percentNeuroCredible = x.neuroCredibleCount / x.neuroCredibilityTotal;
            x.percentNeuroNotCredible = x.neuroNotCredibleCount / x.neuroCredibilityTotal;
            x.percentNeuroQuestionable = x.neuroQuestionableCount / x.neuroCredibilityTotal;

            x.percentPsychCredible = x.psychCredibleCount / x.psychCredibilityTotal;
            x.percentPsychNotCredible = x.psychNotCredibleCount / x.psychCredibilityTotal;
            x.percentPsychQuestionable = x.psychQuestionableCount / x.psychCredibilityTotal;

            x.percentDiagnosisFoundYes = x.diagnosisFoundYesCount / x.diagnosisFoundTotal;
            x.percentDiagnosisFoundNo = x.diagnosisFoundNoCount / x.diagnosisFoundTotal;
            x.percentDiagnosisFoundRuleOut = x.diagnosisFoundRuleOutCount / x.diagnosisFoundTotal;

            x.percentIssueInDisputeApprovedYes = x.issueInDisputeApprovedYes / x.issueInDisputeApprovedTotal;
            x.percentIssueInDisputeApprovedNo = x.issueInDisputeApprovedNo / x.issueInDisputeApprovedTotal;
            x.percentIssueInDisputeApprovedUnknown = x.issueInDisputeApprovedUnknown / x.issueInDisputeApprovedTotal;

        });
    }
    
    showTab(index) {
        this.visibleTab = index;
    }
}