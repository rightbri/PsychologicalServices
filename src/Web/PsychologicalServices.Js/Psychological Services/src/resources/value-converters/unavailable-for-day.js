import moment from 'moment';

export class UnavailableForDayValueConverter {
	toView(array, day) {
		let compareDay = moment.utc(day);
		
		return array.filter(item => {
			
			let forDay = item.unavailability.some(unavailability =>
				moment(unavailability.startDate).isSameOrAfter(compareDay.clone().startOf('day')) &&
				moment(unavailability.startDate).isSameOrBefore(compareDay.clone().endOf('day'))
			);

			return forDay;
		});
	}
}