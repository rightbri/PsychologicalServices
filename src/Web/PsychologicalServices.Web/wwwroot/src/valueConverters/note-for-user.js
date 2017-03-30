
export class NoteForUserValueConverter {
	toView(array, user) {
		
		return array.filter(item => {
			return item.recipients.length === 0 ||
				item.recipients.some(recipient => recipient.userId === user.userId);
		});
	}
}