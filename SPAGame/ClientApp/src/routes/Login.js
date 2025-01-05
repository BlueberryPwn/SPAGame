import * as yup from "yup";
import { AuthContext } from "../context/AuthContext";
import axios from "../lib/axios";
import { Button, Label, TextInput } from "flowbite-react";
import { Link, Navigate, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { useForm } from "react-hook-form";
import { useContext, useState } from "react";
import { yupResolver } from "@hookform/resolvers/yup";

const validationSchema = yup.object().shape({
  AccountEmail: yup
    .string()
    .trim()
    .min(3, "Your email address has to contain at least 3 characters.")
    .max(320, "Your email address cannot contain more than 320 characters.")
    .email("The email address must be valid.")
    .required("Please enter your email address."),
  AccountPassword: yup
    .string()
    .trim()
    .min(6, "Your password has to contain at least 6 characters.")
    .max(30, "Your password cannot contain more than 30 characters.")
    .required("Please enter your password."),
});

export const Login = () => {
  const { authToken, setAuthToken } = useContext(AuthContext);
  const navigate = useNavigate();
  const [AccountEmail, setAccountEmail] = useState("");
  const [AccountPassword, setAccountPassword] = useState("");

  const account = { AccountEmail, AccountPassword };

  const {
    register,
    handleSubmit,
    formState: { errors, isValid, isSubmitting },
  } = useForm({
    resolver: yupResolver(validationSchema),
    defaultValues: {
      AccountEmail: "",
      AccountPassword: "",
    },
  });

  const onSubmitHandler = async (data) => {
    //handleSubmit(e, account);

    try {
      const response = await axios.post(
        "https://localhost:44487/Auth/login",
        account
      );
      console.log(response);
      const token = response.data.jwt;
      localStorage.setItem("token", token);
      setAuthToken(token);
      navigate("/", { replace: true });
      toast.success("Logged in successfully.", {
        position: "bottom-right",
      });
    } catch (error) {
      if (error.response.status === 400) {
        console.error(error);
        toast.info("Invalid details.", {
          position: "bottom-right",
        });
      } else if (error.response.status === 504) {
        console.error(error);
        toast.error("ERROR: There's no connection to the server.", {
          position: "bottom-right",
        });
      }
    }
  };

  if (authToken) return <Navigate to="/" replace={true} />;

  return (
    <div className="flex h-screen w-screen flex-col items-center justify-center bg-gradient-to-br from-cyan-500">
      <div className="container-md box-content rounded p-4 border-2 bg-white">
        <h1 className="m-4 p-4 flex items-center justify-center text-xl font-bold">
          Login
        </h1>
        <form className="max-w-md" onSubmit={handleSubmit(onSubmitHandler)}>
          <div className="mb-4 block">
            <Label>Email Address</Label>
            <TextInput
              {...register("AccountEmail")}
              shadow
              type="text"
              placeholder="Email..."
              onChange={(e) => setAccountEmail(e.target.value)}
            />
            <p className="text-sm italic">{errors.AccountEmail?.message}</p>
          </div>
          <div className="mb-4 block">
            <Label>Password</Label>
            <TextInput
              {...register("AccountPassword")}
              shadow
              type="password"
              placeholder="Password..."
              onChange={(e) => setAccountPassword(e.target.value)}
            />
            <p className="text-sm italic">{errors.AccountPassword?.message}</p>
          </div>
          <div className="m-2 p-2 flex items-center justify-center">
            <Button type="submit" disabled={!isValid || isSubmitting}>
              Login
            </Button>
          </div>
          <p className="mt-4 flex items-center justify-center font-medium italic text-xs">
            Don't have an account?
          </p>
          <Link to="/register">
            <span className="flex items-center justify-center font-medium italic text-xs underline">
              Click here to register.
            </span>
          </Link>
        </form>
      </div>
    </div>
  );
};

export default Login;
