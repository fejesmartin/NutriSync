export class User {
    userName: string;
    email: string;
    token: string;
    constructor(username: string, email: string, token: string){
        this.userName = username;
        this.email = email;
        this.token = token;
    }
}