
export class UserAvailability {
	
	isAvailable(user, date) {
		return userIsAvailable(user, date);
	}
}

function dateIsWithinUnavailability(date, unavailability) {
	return unavailability.startDate <= date && unavailability.endDate >= date;
}

function userIsAvailable(user, date) {
	return (
		!user.unavailability ||
		!user.unavailability.some(unavailability => dateIsWithinUnavailability(date, unavailability))
	) && (
		user.isActive === true ||
		user.dateInactivated >= date
	);
}