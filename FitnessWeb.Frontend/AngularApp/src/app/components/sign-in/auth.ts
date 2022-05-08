export interface AuthResponseDto {
    isAuthSuccessful: boolean;
    errorMessage: string;
    token: string;
}

export interface UserForAuthenticationDto {
    email: string;
    password: string;
}

export interface UserForRegistrationDto {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    confirmPassword: string;
    birthdate: Date;
    weight: number,
    height: number
}

export interface RegistrationResponseDto {
    isSuccessfulRegistration: boolean;
    errros: string[];
}