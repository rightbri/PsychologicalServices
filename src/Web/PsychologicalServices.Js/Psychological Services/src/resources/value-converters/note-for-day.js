import moment from 'moment';

export class NoteForDayValueConverter {
	toView(array, day) {
		let compareDay = moment(day);
		
		return array.filter(item => {
			
			let forDay = !item.note.deleted && (
				item.fromDate === null || 
				!moment(item.fromDate).isAfter(compareDay.clone().endOf('day'))
			) && (
				item.ToDate === null ||
				moment(item.toDate).isAfter(compareDay.clone().startOf('day'))
			);

			return forDay;
		});
	}
}