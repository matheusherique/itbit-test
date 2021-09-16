export interface GenreFK {
    genreId: number;
    description: string;
}

export interface User {
    userId: number;
    name: string;
    birthday: Date;
    email: string;
    password: string;
    active: boolean;
    genreId: number;
    genreFK: GenreFK;
}

export interface Users {
    data: User[];
}