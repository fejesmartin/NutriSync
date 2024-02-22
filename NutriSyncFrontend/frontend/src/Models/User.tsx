export class User {
    userName: string;
    email: string;
    token: string;
    firstName: string | null;
    lastName: string | null;
    profilePictureUrl: string | null;

    constructor(username: string, email: string, token: string, firstName: string | null = null, lastName: string | null = null, profilePictureUrl: string | null = null){
        this.userName = username;
        this.email = email;
        this.token = token;
        this.firstName = firstName;
        this.lastName = lastName;
        this.profilePictureUrl = profilePictureUrl;
    }

    updateProfilePicture(profilePictureUrl: string | null): void {
        this.profilePictureUrl = profilePictureUrl;
        localStorage.setItem('profilePictureUrl', profilePictureUrl || '');
    }
}