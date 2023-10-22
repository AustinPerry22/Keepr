export class Profile {
  constructor(data)
  {
    this.id = data.id
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.coverImg ? data.coverImg : "https://images.unsplash.com/photo-1487088678257-3a541e6e3922?auto=format&fit=crop&q=60&w=500&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8Ymxhbmt8ZW58MHx8MHx8fDA%3D"
  }
}

export class Account extends Profile {
  constructor(data) {
    super(data)
    this.email = data.email
  }
}
