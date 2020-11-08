import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class AppointmentProtocolResponseStatistics {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;

        this.searchMonths = null;
        this.visibleTab = 0;
    }

    activate() {
        this.questionsMap = this.getQuestionsMap();
        this.responseMap = this.getResponseMap();

        return this.context.getUser().then(user => this.user = user);
    }

    search() {
        this.dataRepository.searchAppointmentProtocolResponseData({
            'companyId': this.user.company.companyId,
            'months': this.searchMonths
        }).then(data => {
            this.appointmentProtocolResponseData = data;

            this.appointmentProtocolResponsesByPsychometrist = this.appointmentProtocolResponseData.reduce(function(accumulator, currentValue) {
                let psychometrist = accumulator.find(element =>
                    element.psychometristId === currentValue.psychometristId
                );

                if (psychometrist === undefined) {
                    psychometrist = {
                        'psychometristId': currentValue.psychometristId,
                        'firstName': currentValue.psychometristFirstName,
                        'lastName': currentValue.psychometristLastName,
                        'questions': []
                    };

                    accumulator.push(psychometrist);
                }

                let question = psychometrist.questions.find(element =>
                    element.id === currentValue.question
                );

                if (question === undefined) {
                    question = {
                        'id': currentValue.question,
                        'order': this.questionsMap[currentValue.question].order,
                        'responses': [],
                        'detailsVisible': false
                    };

                    psychometrist.questions.push(question);
                }

                let response = question.responses.find(element =>
                    element.appointmentId === currentValue.appointmentId  
                );

                if (response === undefined) {
                    response = {
                        'appointmentId': currentValue.appointmentId,
                        'assessmentId': currentValue.assessmentId,
                        'appointmentTime': currentValue.appointmentTime,
                        'claimantId': currentValue.claimantId,
                        'claimantFirstName': currentValue.claimantFirstName,
                        'claimantLastName': currentValue.claimantLastName,
                        'response': currentValue.response,
                        'responseText': currentValue.response ? this.responseMap[currentValue.response] : 'Unanswered'
                    };

                    question.responses.push(response);
                }

                return accumulator;
            }.bind(this), []);

            for (let i = 0; i < this.appointmentProtocolResponsesByPsychometrist.length; i++) {
                let p = this.appointmentProtocolResponsesByPsychometrist[i];

                for (let j = 0; j < p.questions.length; j++) {
                    let q = p.questions[j];

                    let relevantResponses = q.responses.filter(element => element.response && (element.response === 1 || element.response === 2));
                    let yesResponses = q.responses.filter(element => element.response && element.response === 1);
                    let yesCount = yesResponses.length;
                    let totalCount = relevantResponses.length;

                    q.numberYes = yesCount;
                    q.numberTotal = totalCount;
                    q.percentYes = yesCount / totalCount;
                }
            }
        });
    }
    
    showTab(index) {
        this.visibleTab = index;
    }

    getQuestionsMap() {
        return {
            'AdvisedOfUnexpectedDelaysId': { 'description': 'Did you advise everyone of any unexpected delays?', 'order': 7 },
            'AfterAssessmentNotificationId': { 'description': 'Shortly after the assessment was finished, did you message everyone to advise if complete or when and why the person chose to leave?', 'order': 8 },
            'AllFormsCompletedId': { 'description': 'Are all forms COMPLETELY filled out (no questions left without an answer)?', 'order': 13 },
            'AllPapersHaveClaimantInitialsAndDateId': { 'description': 'Do all papers/booklet pages have the claimant’s initials and date?', 'order': 9 },
            'AskedWhichTestsShouldBeRemovedId': { 'description': 'Did you ask in writing what tests (if any) should be removed from the battery?', 'order': 6 },
            'ClaimantArrivalNotificationId': { 'description': 'Within a few minutes of the claimant’s arrival, did you notify everyone? If applicable, did you continue to check the waiting room until your claimant showed?', 'order': 2 },
            'CovidFormsCompletedBeforeEnteringRoomId': { 'description': 'Did you fully complete the COVID forms before the claimant arrived into the room?', 'order': 3 },
            'ErrorCheckedObservationsId': { 'description': 'Have you read over your Observations for errors?', 'order': 12 },
            'OnTimeArrivalAndNotificationId': { 'description': 'Did you show up at least 15 minutes before the assessment start time and within a few minutes of your arrival, did you notify everyone?', 'order': 1 },
            'RelevantObservationsDocumentedId': { 'description': 'Did you make sure you documented all relevant information on your Observations?', 'order': 11 },
            'RespondedToQuestionsWithinRequiredTimeframeId': { 'description': 'Did you respond to any emails/messages about this file within an hour of getting the same?', 'order': 18 },
            'ScansUploadedNotificationId': { 'description': 'Did you upload all scans into Tresorit and notify Dr. Watson, Claire and Michelle when it was done?', 'order': 15 },
            'ScoringDoubleCheckedId': { 'description': 'Did you double check scoring?', 'order': 10 },
            'SpareSetReplenishmentRequestSentId': { 'description': 'If you used anything from your spare set, did you ask Claire for an extra copy?', 'order': 17 },
            'StapledItemsTogetherId': { 'description': 'Did you staple everything back together?', 'order': 19 },
            'TestedClaimantsEnglishReadingLevelId': { 'description': 'Did you start your assessment by testing the claimant’s “English Reading Level”?', 'order': 4 },
            'TimeAssessmentLabelCompletedId': { 'description': 'Is the Time Assessment Label filled out?', 'order': 14 },
            'TommSimsScoreNotificationId': { 'description': 'In a timely manner, did you message everyone with the TOMM/SIMS scores?', 'order': 5 },
            'UploadedScanLegibilityVerifiedId': { 'description': 'Did you check that the scans that are in Tresorit are clear/legible?', 'order': 16 },
            'WillPersonallyDropOffPackageId': { 'description': 'Are you going to personally drop off the package to Dr. Watson’s house after the assessment?', 'order': 20 }
        };
    }

    getResponseMap() {
        return {
            '1': 'yes',
            '2': 'no',
            '3': 'N/A'
        };
    }

    toggleDetails(question) {
        question.detailsVisible = !question.detailsVisible;
    }
}