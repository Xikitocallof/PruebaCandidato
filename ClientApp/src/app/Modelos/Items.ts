
export class Items
{
  constructor() {
    this.Name = '';
    this.Children = [];
  }
  Name: string;
  Children: Children[];
}
class Children {
  constructor() {
    this.Name = '';
    this.Children = [];
  }
  Name: string;
  Children: Children[];
}
