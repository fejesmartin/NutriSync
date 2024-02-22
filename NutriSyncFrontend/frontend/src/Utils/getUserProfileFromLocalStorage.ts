import { User } from "../Models/User";

export function getUserProfileFromLocalStorage(): User | null {
    const userProfileString = localStorage.getItem('profile');
    if (userProfileString) {
      const userProfile = JSON.parse(userProfileString);
      return new User(userProfile.userName, userProfile.email, userProfile.token, userProfile.profilePictureUrl);
    }
    return null;
  }
  