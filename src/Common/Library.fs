namespace Common

type UserId = UserId of int
type UserName = UserName of string
type EmailAddress = EmailAddress of string

type UpdateProfileRequest = {
    UserId : UserId
    Name : UserName
    EmailAddress : EmailAddress
}
