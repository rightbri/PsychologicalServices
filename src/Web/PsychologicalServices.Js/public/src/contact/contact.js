
export class Contact {

    activate() {
        this.contactInfo = this.getContactInfo();
    }

    getContactInfo() {
        var contactInfo = {
            address: {
                'address1': '1801 Lakeshore Road West',
                'address2': 'PO Box 52565 Turtle Creek',
                'city': 'Mississauga',
                'province': 'Ontario',
                'postalCode': 'L5J 1J6'
            },
            email: 'doctormarkwatson@gmail.com',
            linkedInAddress: 'https://ca.linkedin.com/in/markwatsonpsychologicalservice'
        };

        return contactInfo;
    }
}