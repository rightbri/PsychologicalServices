
export class Index {
    
    activate() {
        this.events = this.getEvents();
    }

    getEvents() {

        var events = [
            {'eventId': 1,'name': 'OTLA 2017 Fall Conference','description': null,'location': 'Metro Toronto Conference Centre, Toronto','locationMap': null,'linkText': 'link','linkHref': 'https://www.otla.com/index.cfm?pg=calendar','time': 'November 16, 2017'},
            {'eventId': 2,'name': 'OTLA 2017 Disability Conference','description': null,'location': 'Twenty Toronto Street Conferences and Events, Toronto','locationMap': null,'linkText': 'link','linkHref': 'https://www.otla.com/index.cfm?pg=calendar','time': 'May 26, 2017'},
            {'eventId': 3,'name': '31st Annual Joint Insurance Seminar','description': null,'location': null,'locationMap': null,'linkText': 'link','linkHref': 'http://www.hamiltonlaw.on.ca/events-cpd','time': 'May 2, 2017'},
            {'eventId': 4,'name': 'OTLA 2017 Spring Conference','description': null,'location': 'Twenty Toronto Street Conferences and Events, Toronto','locationMap': null,'linkText': 'link','linkHref': 'https://www.otla.com/index.cfm?pg=calendar','time': 'April 27, 2017'},
            {'eventId': 5,'name': 'Recent Case Law and the Legal Perspective on Expert Evidence and Report Writing-CAPDA Workshop','description': null,'location': 'Albany Club, 91 King Street East, Toronto, ON   M5C 1G3','locationMap': null,'linkText': 'link','linkHref': 'http://capda.ca/resources/workshop-details/2017/03/01/recent-case-law-and-the-legal-perspective-on-expert-evidence-and-report-writing','time': 'April 21, 2017, 8:00am - 1:00pm'},
            {'eventId': 6,'name': 'American Academy of Forensic Psychology: Comtemporary Issues in Forensic Psychology','description': null,'location': 'Chicago','locationMap': null,'linkText': 'link','linkHref': 'https://www.regonline.com/builder/site/Default.aspx?eventid=1891004','time': 'April 19 - 23, 2017'},
            {'eventId': 7,'name': 'Fourth Annual NRVMS/DSF Threshold Conference-Psychological/Psychiatric Impairment','description': null,'location': 'National Club,303 Bay Street, Toronto','locationMap': null,'linkText': 'link','linkHref': 'http://nrvmsdsfcharityevent.ca','time': 'April 19, 2017'},
            {'eventId': 8,'name': 'Canadian Defence Lawyers AB Spring Symposium','description': null,'location': 'Toronto','locationMap': null,'linkText': 'link','linkHref': 'https://www.cdlawyers.org/?page=220','time': 'April 13, 2017'},
            {'eventId': 9,'name': 'HLA Annual Dinner','description': null,'location': 'Art Gallery of Hamilton,123 King Street West, Hamilton','locationMap': null,'linkText': 'link','linkHref': 'http://www.hamiltonlaw.on.ca/docs/default-source/event-flyers/2017-annual-dinner-invite.pdf?sfvrsn=2','time': 'March 30, 2017 5:30pm'},
            {'eventId': 10,'name': 'Canadian Defence Lawyers','description': null,'location': 'Toronto','locationMap': null,'linkText': 'link','linkHref': 'https://www.cdlawyers.org/?page=220','time': 'March 30, 2017'},
            {'eventId': 11,'name': 'HLA Winter Special','description': null,'location': 'Serve Ping Pong,105-115 King St East (2nd Floor), Hamilton','locationMap': null,'linkText': 'link','linkHref': 'http://www.hamiltonlaw.on.ca/docs/default-source/event-flyers/february-pub-night-2017.pdf?sfvrsn=2','time': 'February 23, 2017 5:30pm - 7:30pm'},
            {'eventId': 12,'name': 'Canadian Defence Lawyers Insurance Coverage Symposium','description': null,'location': 'Toronto','locationMap': null,'linkText': 'link','linkHref': 'https://www.cdlawyers.org/?page=220','time': 'February 1, 2017'},
            {'eventId': 13,'name': 'OIAA Claims Conference','description': null,'location': null,'locationMap': null,'linkText': 'link','linkHref': 'https://www.oiaa.com/about-us/claims-conference/','time': 'January 31, 2017'},
            {'eventId': 14,'name': 'OIAA 2016 Holiday Party','description': null,'location': 'Fairmont Royal York, 100 Front Street West, Toronto','locationMap': null,'linkText': 'link','linkHref': 'https://www.oiaa.com/events/2016-christmas-party/','time': 'December 14, 2016 6:00pm'},
            {'eventId': 15,'name': 'Ontario Minister of Labour First PTSD Summit','description': null,'location': null,'locationMap': null,'linkText': 'link','linkHref': 'http://www.csme.org/events/EventDetails.aspx?id=881250&group=','time': 'December 6, 2016 7:30 - 9:00'},
            {'eventId': 16,'name': 'OIAA Hamilton Chapter Christmas Party','description': null,'location': 'Shoeless Joe\'s at 1250 Brant Street, Burlington ON','locationMap': null,'linkText': 'link','linkHref': 'http://www.oiaahamilton.ca/event/oiaa-hamilton-christmas-party/','time': 'November 30, 2016 5:30pm - 9:00pm'},
            {'eventId': 17,'name': 'The &#8220;F&#8221; Word: On the Nature of Feigning, Malingering, Conversion and Beyond','description': null,'location': 'Courtyard Toronto, 475 Yonge Street, Toronto','locationMap': null,'linkText': null,'linkHref': null,'time': 'November 25, 2016 8:00am'},
            {'eventId': 18,'name': 'Insurance Coverage Primer','description': null,'location': 'Hyatt Regency, 370 King Street West, Toronto','locationMap': null,'linkText': 'agenda','linkHref': 'events/Insurance Coverage Primer Agenda.pdf','time': 'November 24, 2016 9:00am'}
        ];

        return events;
    }
}