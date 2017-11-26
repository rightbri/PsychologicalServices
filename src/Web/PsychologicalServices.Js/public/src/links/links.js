
export class Links {

    activate() {
        this.links = this.getData();
    }

    getData() {
        var links = [
            { 'url': 'http://www.biac-aclc.ca', 'text': 'Brain Injury Association of Canada' },    
            { 'url': 'http://www.biaph.com', 'text': 'Brain Injury Association of Peel and Halton' },
            { 'url': 'http://www.cdlawyers.org', 'text': 'Canadian Defence Lawyers' },
            { 'url': 'http://www.canadian-health-network.ca', 'text': 'Canadian Health Network' },
            { 'url': 'http://www.cmha.ca', 'text': 'Canadian Mental Health Association' },
            { 'url': 'http://www.ontario.chma.ca', 'text': 'Canadian Mental Health Association - Ontario Division' },
            { 'url': 'http://www.canmat.org', 'text': 'Canadian Network for Mood and Anxiety Treatments' },
            { 'url': 'http://www.cpa.ca', 'text': 'Canadian Psychological Association' },
            { 'url': 'http://www.crhspp.ca', 'text': 'Canadian Register of Health Service Providers in Psychology' },
            { 'url': 'http://www.camh.net', 'text': 'Centre for Addiction and Mental Health' },
            { 'url': 'http://www.cpo.on.ca', 'text': 'College of Psychologists of Ontario' },
            { 'url': 'http://www.fsco.gov.on.ca', 'text': 'Financial Services Commission of Ontario' },
            { 'url': 'http://www.hbia.ca', 'text': 'Hamilton Brain Injury Association' },
            { 'url': 'http://www.lrpa.ca', 'text': 'London Regional Psychological Association' },
            { 'url': 'http://www.psychdirect.com', 'text': 'Mental Health Education' },
            { 'url': 'http://www.obia.on.ca', 'text': 'Ontario Brain Injury Association' },
            { 'url': 'http://www.psych.on.ca', 'text': 'Ontario Psychological Association' },
            { 'url': 'http://www.otla.com', 'text': 'Ontario Trial Lawyers Association' },
            { 'url': 'http://www.psychologytoday.com', 'text': 'Psychology Today' }
        ];

        return links;
    }
}