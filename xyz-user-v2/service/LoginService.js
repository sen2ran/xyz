import Instance from "./instance";

export const Login = async (payload) => {
  try {
    return await Instance.instance.post(`/auth/user`, payload);
  } catch (error) {
    return error;
  }
};

export const Registration = async (payload) => {
  try {
    return await Instance.instance.post(`/user`, payload);
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
