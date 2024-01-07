namespace E_commerceAPI.Application.Constants
{
    public static class Messages
    {
        public static class User
        {
            public static string UserNotFound => "User not found.";
            public static string ChangePasswordRequest => "Email verification link was sent to your e-mail address.";
            public static string PasswordChanged => "Your password has been successfully changed.";
            public static string IncorrectPassword => "Incorrect password.";
            public static string RefreshTokenExpired => "Refresh token has expired.";
            public static string PasswordUpdateFailed => "Password update failed.";
            public static string UserCreated => "User created.";
            public static string UserDeleted => "User account has been deactivated.";
            public static string UserHardDeleted => "User deleted.";

            public static string UserUpdated = "User Updated.";
            public static string UserAlreadyExists = "User already exists.";
            public static string AuthorizationDenied = " Authorization denied!";
            public static string ValidationError = "One or more user information validation errors occurred.";
            public static string ForgotPassword = "Password reset link was sent to your e-mail address.";
            public static string ChangePassword = "Your password has been updated successfully.";
        }
        public static class Product
        {
            public static string ProductNotFound = "Product Not Found.";
        }
    }
}
