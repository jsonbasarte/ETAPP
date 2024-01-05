interface IResponseHandler {
    data: any
}

export function responseHandler(fn: () => any) {
    try {
        const res: IResponseHandler = fn();

        return res.data;
    }
}