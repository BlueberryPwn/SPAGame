import "../styles/Register.css";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

export const Register = () => {
  const schema = yup.object().shape({
    name: yup.string().min(3).max(12).required("Please enter a name."),
    email: yup
      .string()
      .email()
      .max(320)
      .required("Please enter an email address."),
    password: yup.string().min(6).max(30).required("Please enter a password"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmit = (data) => {
    console.log(data);
  };

  return (
    <div className="form">
      <div className="title">
        <h1>Register</h1>
      </div>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="formList">
          <label>Name</label>
          <input type="text" placeholder="Name..." {...register("name")} />
          <p className="error">{errors.name?.message}</p>
          <label>Email Address</label>
          <input type="text" placeholder="Email..." {...register("email")} />
          <p className="error">{errors.email?.message}</p>
          <label>Password</label>
          <input
            type="password"
            placeholder="Password..."
            {...register("password")}
          />
          <p className="error">{errors.password?.message}</p>
          <input type="submit" />
        </div>
      </form>
    </div>
  );
};

export default Register;
