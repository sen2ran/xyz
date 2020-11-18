import axios from "axios";
import Config from "@/service/config.js";

const baseURL = Config.baseURL;

let instanceToken = axios.create({
  baseURL: baseURL,
});

// Alter defaults after instance has been created
instanceToken.interceptors.request.use(
  function(config) {
    config.headers = {
      "x-abc-token": JSON.parse(localStorage.getItem("user")).token,
    };
    return config;
  },
  function(error) {
    return Promise.reject(error);
  }
);

const instance = axios.create({
  baseURL: baseURL,
});

export default {
  instanceToken: instanceToken,
  instance: instance,
};
