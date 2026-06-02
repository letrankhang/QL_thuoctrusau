using System;

namespace QL_CuaHangBanThuocTruSau.Utils
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static Result Success(string message = "") => new Result(true, message);

        public static Result Failure(string message) => new Result(false, message);
    }

    public class Result<T> : Result
    {
        public T Data { get; }

        private Result(bool isSuccess, string message, T data) : base(isSuccess, message)
        {
            Data = data;
        }

        public static Result<T> Success(T data, string message = "") => new Result<T>(true, message, data);

        public static new Result<T> Failure(string message) => new Result<T>(false, message, default);
    }
}
