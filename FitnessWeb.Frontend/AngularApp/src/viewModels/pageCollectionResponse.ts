export interface PageCollectionResponse {
        totalItemsCount: number;
        items: never[];
        currentPage: number;
}

export interface FilterModel {
        page: number,
        limit: number,
        term: string,
        sortedField: string,
        sortAsc: boolean
}

