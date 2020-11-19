import Instance from "./instance";

export const GetAll = async payload => {
  try {
    return await Instance.instance.get(`/dressType/all`, payload);
  } catch (error) {
    return error;
  }
};
