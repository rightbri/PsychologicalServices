import {inject} from 'aurelia-framework';

function htmlEncode(html) {
  return document.createElement('a').appendChild( 
    document.createTextNode(html)).parentNode.innerHTML;
}

@inject(Element)
export class PreserveBreaksCustomAttribute {
  constructor(element) {
    this.element = element;
  }

  valueChanged() {
    let html = htmlEncode(this.value);
    html = html.replace(/\r/g, '').replace(/\n/g, '<br/>');
    this.element.innerHTML = html;
  }
}