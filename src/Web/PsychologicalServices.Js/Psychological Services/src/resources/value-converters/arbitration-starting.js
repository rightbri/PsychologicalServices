import moment from 'moment';

export class ArbitrationStartingValueConverter {
	toView(array, day) {
		let compareDay = moment.utc(day);
		
		return array.filter(item => {
			
			let forDay = (
				!moment(item.startDate).isAfter(compareDay.clone().endOf('day'))
			) && (
				moment(item.startDate).isSameOrAfter(compareDay.clone().startOf('day'))
			);

			return forDay;
		});
	}
}