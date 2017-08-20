import moment from 'moment';

export class ArbitrationAvailabilityValueConverter {
	toView(array, day) {
		let compareDay = moment.utc(day);
		
		return array.filter(item => {
			
			let forDay = (
				!moment(item.availableDate).isAfter(compareDay.clone().endOf('day'))
			) && (
				moment(item.availableDate).isSameOrAfter(compareDay.clone().startOf('day'))
			);

			return forDay;
		});
	}
}