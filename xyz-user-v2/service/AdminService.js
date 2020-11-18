import Instance from "./instance";

export const AddUser = async (payload) => {
  try {
    return await Instance.instance.post(`/admin`, payload);
  } catch (error) {
    return error;
  }
};

export const EditUser = async (payload) => {
  try {
    return await Instance.instance.put(`/admin`, payload);
  } catch (error) {
    return error;
  }
};

export const GetAll = async (payload) => {
  try {
    return await Instance.instance.get(`/admin/all`, payload);
  } catch (error) {
    return error;
  }
};

export const DeleteUser = async (payload) => {
  try {
    return await Instance.instance.delete(`/admin/${payload}`);
  } catch (error) {
    return error;
  }
};
