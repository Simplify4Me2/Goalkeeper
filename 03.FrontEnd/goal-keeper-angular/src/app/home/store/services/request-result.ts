export interface RequestResult<T> {
    data: T;
    messages: Array<string>;
}