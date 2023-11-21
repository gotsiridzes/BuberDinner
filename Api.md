# Buber Dinner API
- [Buber Dinner Api](#buber-diner-api)
  - [Auth](#auth)
	- [Register](#register)
	  - [Register Request](#register-request)
	  - [Register Response](#register-response)
	- [Login](#login)
	  - [Login Request](#login-request)
	  - [Login Response](#login-response)

## Auth

### Register
```js
POST {{host}}/auth/register
```

#### Register Request
```json
{
    "firstName": "Saba",
    "lastName": "Gotsiridze",
    "email": "saba@gotsiridze.com",
    "password": "asdASD123"
}
```

#### Register Response
```js
200 OK
```

### Login
```js
POST {{host}}/auth/login
```

#### Login Request
```json
{
    "email":"saba@gotsiridze.com",
    "password": "asdASD123"
}
```

#### Login Response
```js
200 OK
```
