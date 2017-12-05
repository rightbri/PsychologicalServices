
export class Index {
    activate() {
        this.events = this.getData();
    }

    getData() {
        return this.getEvents();
    }

    getEvents() {

        var events = [
            { 'name': 'Dont be CATatonic...', 'location': '20 Toronto Street, Toronto, ON M5C 2B8', 'linkHref': 'http://www.mlst.ca/?page=52', 'time': 'Wed Feb 21 2018 from 9:00 am - 12:30 pm' }
        ];

        return events;
    }
}