
export class AppointmentInStatusesValueConverter {
	toView(array, statuses) {
		if (!statuses || !Array.isArray(statuses)) {
			return array;
		}
		
		return array.filter(item => {
			return statuses.indexOf(item.appointmentStatus.appointmentStatusId) > -1;
		});
	}
}