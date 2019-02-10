export class SortOrder {
  orderBy: string;
  sortOrder: string;
  name: string;
  constructor(orderBy: string, sortOrder: string, name: string) {
    this.orderBy = orderBy;
    this.sortOrder = sortOrder;
    this.name = name;
  }
}