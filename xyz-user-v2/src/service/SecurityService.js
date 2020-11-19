import Instance from "./instance";

export const AddSecurity = async (payload) => {
  try {
    return await Instance.instance.post(`/security`, payload);
  } catch (error) {
    return error;
  }
};

export const EditSecurity = async (payload) => {
  try {
    return await Instance.instance.put(`/security`, payload);
  } catch (error) {
    return error;
  }
};

export const GetAll = async (payload) => {
  try {
    return await Instance.instance.get(`/security/all`, payload);
  } catch (error) {
    return error;
  }
};

export const DeleteSecurity = async (payload) => {
  try {
    return await Instance.instance.delete(`/security/${payload}`);
  } catch (error) {
    return error;
  }
};
