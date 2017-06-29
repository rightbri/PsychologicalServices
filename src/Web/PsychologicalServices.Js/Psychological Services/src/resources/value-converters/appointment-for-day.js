import moment from 'moment';

export class AppointmentForDayValueConverter {
	toView(array, day) {
		let compareDay = moment(day);
		
		return array.filter(item => {
			let itemDate = moment.utc(item.appointmentTime);
			
			let forDay = !itemDate.isBefore(compareDay.clone().startOf('day')) && !itemDate.isAfter(compareDay.clone().endOf('day'));
			
			return forDay;
		});
	}
}