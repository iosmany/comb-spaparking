

export class ApiResponse<D> {

    data: D;
    errors: string[] = [];

    constructor(data: D, errors: string[]) {
        this.data = data;
        this.errors = errors;
    }

}