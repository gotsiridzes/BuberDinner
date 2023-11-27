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
    "firstName": "",
    "lastName": "",
    "email": "",
    "password": ""
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
    "email":"",
    "password": ""
}
```

#### Login Response
```js
200 OK
```
