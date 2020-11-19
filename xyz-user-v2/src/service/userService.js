import Instance from "./instance";

export const AddUser = async (payload) => {
  try {
    return await Instance.instance.post(`/user`, payload);
  } catch (error) {
    return error;
  }
};

export const EditUser = async (payload) => {
  try {
    return await Instance.instance.put(`/user`, payload);
  } catch (error) {
    return error;
  }
};

export const GetAll = async (payload) => {
  try {
    return await Instance.instance.get(`/user/all`, payload);
  } catch (error) {
    return error;
  }
};

export const DeleteUser = async (payload) => {
  try {
    return await Instance.instance.delete(`/user/${payload}`);
  } catch (error) {
    return error;
  }
};
