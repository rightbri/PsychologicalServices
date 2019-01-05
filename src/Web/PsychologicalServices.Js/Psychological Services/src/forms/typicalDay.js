import {Context} from 'common/context';
import {inject} from 'aurelia-framework';

@inject(Context)
export class TypicalDay {

    constructor(context) {
        this.context = context;

        this.issues = [];
        this.issueDescriptions = [];
        this.frequencies = [];
        this.abilities = [];
        this.tasks = [];
        
        this.taskFrequency = "";
        this.taskName = "";
        this.taskDescription = "";

        this.pronoun = "His";
        this.creatingTask = false;

		this.issueMatcher = (a, b) => a && b && a.abbreviation === b.abbreviation;
    }
    
    activate() {
		return this.getData();
    }
    
    getData() {
        return this.context.getUser()
            .then(user => {
                this.user = user;
        
                return Promise.all([
                    this.getFrequencies().then(data => this.frequencies = data),
                    this.getTasks().then(data => this.tasks = data),
                    this.getIssues().then(data => this.issues = data),
                ]);
            });
    }

    getIssueCombinations() {
        let combinations = getCombinations(this.issues.map(item => item.abbreviation));

        let validCombos = combinations
            .filter(item => item.length > 0);

        return validCombos;
    }

    getIssueDescriptions() {
        let issueDescriptions = [];

        let issueCombinations = this.getIssueCombinations();

        for (let i = 0; i < issueCombinations.length; i++) {
            let issueAbbreviations = issueCombinations[i];
            
            let matchingTasks = this.tasks.filter(function(task) {
                let lengthMatch = task.issues.length === issueAbbreviations.length;
                let taskMatch = issueAbbreviations.every(abbreviation => task.issues.some(taskIssue => taskIssue.abbreviation === abbreviation));
                return lengthMatch && taskMatch;
            });

            let description = this.issues
                .filter(issue => issueAbbreviations.some(abbr => issue.abbreviation === abbr))
                .map(issue => issue.description)
                .reduce((accumulator, currentValue, index, array) => {
                    let isFirst = index === 0;
                    let isLast = index === array.length - 1;
                    let useAnd = isLast && !isFirst;
                    let useComma = !isLast && array.length > 2;

                    return accumulator + (useAnd ? " and " : "") + currentValue + (useComma ? ", " : "");
                }, "");
            
            let issueDescription = {
                "description": description,
                "tasks": matchingTasks
            };

            issueDescriptions.push(issueDescription);
        }

        return issueDescriptions.filter(item => item.tasks.some(t => true));
    }

    recalculate() {
        this.issueDescriptions = this.getIssueDescriptions();
    }

    addTask() {
        this.creatingTask = true;
    }

    cancelTask() {
        this.resetTask();
    }

    resetTask() {
        this.taskFrequency = "";
        this.taskName = "";
        this.taskDescription = "";
        this.creatingTask = false;
    }

    isValidTask() {
        return this.taskFrequency && this.taskName && this.taskDescription;
    }

    saveTask() {
        if (this.isValidTask()) {
            this.tasks.push({
                "frequency": this.taskFrequency,
                "name": this.taskName,
                "description": this.taskDescription,
                issues: [],
                isCustom: true,
            });
    
            this.resetTask();
        }
    }

    removeTask(task) {
        if (confirm('Remove task\nAre you sure?')) {
            this.tasks.splice(this.tasks.indexOf(task), 1);
        }
    }

    getTasks() {
        var tasks = [
            { "frequency": "Daily", "name": "Sleep/rest", "description": "Sleeping/Resting", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Groom", "description": "Grooming  (Bathing, brushing teeth, shaving) ", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Dress", "description": "Dressing (pick your clothes, dressing/undressing yourself etc)", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Prepare breakfast/lunch", "description": "Prepare Breakfast/Lunch", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Eat breakfast/lunch", "description": "Eat Breakfast/lunch", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Travel to work/school", "description": "Travel to and from work/school", issues: [], "isCustom": false },//
            { "frequency": "Daily", "name": "Take care of children", "description": "Take care of the children/spending time with them", issues: [], "isCustom": false },//
            { "frequency": "Daily", "name": "Work/attend school", "description": "Work/Attend school", issues: [], "isCustom": false },//
            { "frequency": "Daily", "name": "Run errands", "description": "Run errands (banking/groceries) etc.", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Prepare dinner/clean up after dinner", "description": "Prepare Dinner/Clean up after dinner", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Eat dinner", "description": "Eat Dinner", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Do indoor household chores", "description": "Indoor Household chores (dishes, laundry) ", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Do outdoor chores", "description": "Outdoor Chores (Gardening/Snow removal)", issues: [], "isCustom": false },//
            { "frequency": "Daily", "name": "Take care of pets", "description": "Taking care of any pets/animals", issues: [], "isCustom": false },//
            { "frequency": "Daily", "name": "Exercise/workout/ be active", "description": "Exercise/Work out/be active", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Read", "description": "Reading", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Watch television/movies", "description": "Watching television/movies ", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Use internet/send and get emails/text messages", "description": "Use Internet/Send and get Emails/Text Messages", issues: [], "isCustom": false },
            { "frequency": "Daily", "name": "Use computer/tablets", "description": "Use the computer/tablets (devices with screens)", issues: [], "isCustom": false },
            { "frequency": "Weekly", "name": "Be involved in any social activities/games", "description": "Social activities/games", issues: [], "isCustom": false },
            { "frequency": "Weekly", "name": "Volunteer", "description": "Volunteering", issues: [], "isCustom": false },
            { "frequency": "Weekly", "name": "Be involved in religious activities", "description": "Religious Activities ", issues: [], "isCustom": false },
            { "frequency": "Monthly/Yearly", "name": "Travel/go on vacation", "description": "Travel/vacation", issues: [], "isCustom": false },
        ];
        
        return getPromise(tasks);
    }

    getIssues() {
        var issues = [
            { "abbreviation": "P", "description": "Pain/Physical issues" },
            { "abbreviation": "M", "description": "Mental health issues" },
            { "abbreviation": "C", "description": "Cognitive issues" }
        ];

        return getPromise(issues);
    }

    getFrequencies() {
        var frequencies = [
            { "name": "Daily", "description": "Daily Basis" },
            { "name": "Weekly", "description": "Weekly Basis" },
            { "name": "Monthly/Yearly", "description": "Monthly/Yearly Basis" }
        ];

        return getPromise(frequencies);
    }
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}


/* Adapted from: https://js-algorithms.tutorialhorizon.com/2015/10/23/combinations-of-an-array/
*/
function getCombinations(arr) {

    let result = [];
    let arrLen = arr.length;
    let power = Math.pow;
    let combinations = power(2, arrLen);
    
    // Time & Space Complexity O (n * 2^n)
    
    for (let i = 0; i < combinations;  i++) {
      let temp = [];
      
      for (let j = 0; j < arrLen; j++) {
        // & is bitwise AND
        if ((i & power(2, j))) {
          temp.push(arr[j]);
        }
      }

      result.push(temp);
    }

    return result;
  }