import moment from 'moment';

export class AppointmentForDayValueConverter {
	toView(array, day) {
		let compareDay = moment(day);
		
		return array.filter(item => {
			let itemDate = moment(item.appointmentTime);
			
			let forDay = itemDate.isAfter(compareDay.clone().startOf('day')) && itemDate.isBefore(compareDay.clone().endOf('day'));
			
			return forDay;
		});
	}
}