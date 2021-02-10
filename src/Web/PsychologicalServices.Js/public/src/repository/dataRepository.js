
export class DataRepository {

	getSiteName() {
		var name = "Mark S. Watson Psychology Professional Corporation";

		var promise = new Promise((resolve, reject) => resolve(name));

		return promise;
	}

	getContactInfo() {
		//maybe fetch from api in the future
		var contactInfo = {
            address: {
                'address1': '1801 Lakeshore Road West',
                'address2': 'PO Box 52565 Turtle Creek',
                'city': 'Mississauga',
                'province': 'Ontario',
                'postalCode': 'L5J 1J0'
            },
            email: 'doctormarkwatson@gmail.com',
            linkedInAddress: 'https://ca.linkedin.com/in/markwatsonpsychologicalservice'
		};
		
		var promise = new Promise((resolve, reject) => resolve(contactInfo));

		return promise;
    }

	getFaqs() {
		//maybe fetch from api in the future
		var faqs = [
			{'question': 'What is a Psychologist?', 'answer': 'A Psychologist studies how we think, feel and behave from a scientific viewpoint and applies this knowledge to help people understand, explain and change their behaviour.'},
			{'question': 'What is Clinical Psychology?', 'answer': 'According to the Canadian Psychological Association (CPA), "Clinical psychology is an integration of science, theory and clinical knowledge for the purpose of understanding, preventing, and relieving psychologically-based distress or dysfunction and to promote subjective well-being and personal development."'},
			{'question': 'What is a Clinical Neuropsychologist?', 'answer': `A Neuropsychologist is an accredited psychologist who studies and practices neuropsychology, the study of the relationship between the brain and spine and behaviour.
			A Neuropsychologist administers a battery of psychometric tests to help diagnose brain disorders that can cause problems with cognitive functioning, such as multi-tasking, thinking, emotions, or behaviour.`},
			{'question': 'What is a neuropsychological assessment?', 'answer': 'A neuropsychological assessment is actually two assessments - a neurocognitive assessment and a psychological assessment.'},
			{'question': 'What is a neurocognitive assessment?', 'answer': 'A Neurocognitive Assessment measures cognition, including memory, attention, and visual motor abilities, and assesses cognitive and psychological validity, does not assess psychological functioning in detail, and may opine on the same, and does not collect information that allows for a formal diagnosis of mood to be made. That is, a Neurocognitive Assessment allows for the diagnosis and discussion of a Neurocognitive Disorder, it does not allow for the diagnosis of any Psychological conditions (e.g., Somatic Symptom Disorder, Major Depressive Disorder, or Posttraumatic Stress Disorder). Such conditions may be suspected and referral made for a formal assessment of the same, but discussion on the same and implications on the current cognitive state are deferred to the Mental Health Assessor on file. If the cause of any cognitive impairment is anything other than the traumatic injury, causation cannot be addressed.'},
			{'question': 'What is a psychological assessment?', 'answer': `Technically, Psychological Assessments assess personality and emotional functioning using standardized, objective measures with comparisons made to persons of same sex, age, or education as warranted. They include standardized, objective measures of validity, including measures of malingering and include clinical interviews.
			In other words, a psychological assessment addresses someone’s mood and mental state. Unlike other physical injuries, someone’s mood and mental state cannot be seen on an x-ray. To determine a person’s mental state, the medical file is reviewed, an interview is performed, and the person is asked to complete numerous questionnaires.
			The questionnaires are objective psychometric measures that provide a “snapshot” of someone’s mood at the time the questionnaires are being completed. (It must be noted that psychology/someone’s mood is fluid and can change with or without a major life event occurring. An example of this would be someone’s mood on Monday morning when their alarm did not go off, they are late for a meeting, go to get in their car and realize they have a flat tire; compared to their mood on a Friday afternoon after getting a notice that they can leave work early and thus can avoid traffic). These questionnaires are very important as they provide a measure of how credible/reliable the information is that is being reported to the assessor.`},
			{'question': 'What is the difference between a Neuropsychological Assessment vs a Neurological Assessment?', 'answer': `Neuropsychological Assessments measure cognition, including memory, attention, and visual motor abilities using standardized testing with comparisons made to persons of same sex, age, or education. It also speaks to the severity of the same and their impact on functioning. Emotional functioning and personality are assessed using standardized testing. Validity issues, including measures of malingering are also assessed using standardized testing.
			Neurology Assessments deal with abnormalities of the nervous system (ie. Illness, injuries, structural changes) and infers cognitive deficits, but typically does not directly test. This type of assessment does not include validity measures.`},
			{'question': 'What is the difference between a Psychological Asssessment and a Psychiatric Assessment?', 'answer': `Psychological Evaluations assess personality and emotional functioning using standardized, objective measures with comparisons made to persons of same sex, age, or education as warranted. They include standardized, objective measures of validity, including measures of malingering and include clinical interviews.
			Psychiatric Evaluations also include clinical interviews, and may include some standardized measures of emotional functioning.`}
		];

		var promise = new Promise((resolve, reject) => resolve(faqs));
		
		return promise;
	}
	
	getLinks() {
		//maybe fetch from api in the future
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
			{ 'url': 'http://www.otla.com', 'text': 'Ontario Trial Lawyers Association' },
			{ 'url': 'http://www.psychologytoday.com', 'text': 'Psychology Today' }
		];

		var promise = new Promise((resolve, reject) => resolve(links));
		
		return promise;
	}

}
