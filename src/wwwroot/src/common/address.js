import {bindable} from 'aurelia-framework';

export class Address {
    @bindable address;

    hasSuite(address) {
        return address && address.suite && address.suite.length > 0;
    }
}