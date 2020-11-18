import Instance from "./instance";

export const AddDress = async (payload) => {
  try {
    return await Instance.instance.post(`/dressType`, payload);
  } catch (error) {
    return error;
  }
};

// export const EditUser = async (payload) => {
//   try {
//     return await Instance.instance.put(`/user`, payload);
//   } catch (error) {
//     return error;
//   }
// };

export const GetAll = async (payload) => {
  try {
    return await Instance.instance.get(`/dressType/all`, payload);
  } catch (error) {
    return error;
  }
};

// export const GetOwnerByName = async (payload) => {
//   try {
//     return await Instance.instance.get(`/owner/list/${payload}`);
//   } catch (error) {
//     return error;
//   }
// };

// export const DeleteUser = async (payload) => {
//   try {
//     return await Instance.instance.delete(`/user/${payload}`);
//   } catch (error) {
//     return error;
//   }
// };
