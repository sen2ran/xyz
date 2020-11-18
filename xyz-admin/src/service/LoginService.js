import Instance from "./instance";

export const Login = async (payload) => {
  try {
    return await Instance.instance.post(`/auth/admin`, payload);
  } catch (error) {
    return error;
  }
};

export const Auth = async (payload) => {
  try {
    return await Instance.instanceToken.get(`/auth`, payload);
  } catch (error) {
    return error;
  }
};
