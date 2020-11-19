<template>
  <!-- BEGIN: Top Bar -->
  <div class="top-bar top-0 left-0 fixed w-full h-16">
    <div class="-intro-y top-bar__content border-b w-full h-full flex px-5">
      <!-- BEGIN: Logo -->
      <a class="hidden md:flex items-center h-full mr-auto">
        <img
          alt="Topson Messenger Tailwind HTML Admin Template"
          class="h-8"
          src="@/assets/logo.svg"
        />
        <div class="text-base font-light ml-4">
          <span class="font-medium">XYZ</span> Online Laundry Management
        </div>
      </a>
      <!-- END: Logo -->
      <a
        class="mobile-menu-toggler flex md:hidden items-center h-full mr-auto px-5 -ml-5"
        href="javascript:;"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-bar-chart-2 w-5 h-5 transform rotate-90"
        >
          <line x1="18" y1="20" x2="18" y2="10"></line>
          <line x1="12" y1="20" x2="12" y2="4"></line>
          <line x1="6" y1="20" x2="6" y2="14"></line>
        </svg>
      </a>
      <!-- 
      <div class="hidden md:flex items-center px-5">
        <a
          href="javascript:;"
          data-toggle="modal"
          data-target="#invite-friends-modal"
          class="button button--primary shadow-md"
          >Invite Friends</a
        >
      </div> -->
      <!-- BEGIN: Notifications -->
      <div class="notification-dropdown dropdown relative">
        <a
          @click="isProfileSet = !isProfileSet"
          class="notification-dropdown__toggler dropdown-toggle h-full flex items-center px-5 relative -mr-3 md:mr-0 md:border-l md:border-r"
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            stroke-width="1"
            stroke-linecap="round"
            stroke-linejoin="round"
            class="feather feather-bell w-5 h-5"
          >
            <path d="M18 8A6 6 0 0 0 6 8c0 7-3 9-3 9h18s-3-2-3-9"></path>
            <path d="M13.73 21a2 2 0 0 1-3.46 0"></path>
          </svg>
          <div
            class="notification-dropdown__toggler__count flex items-center justify-center absolute top-0 right-0 rounded-full"
          >
            2
          </div>
        </a>
        <div
          class="notification-dropdown__content dropdown-box mt-8 absolute top-0 left-0 sm:left-auto sm:right-0 z-20 sm:ml-0"
        >
          <div class="dropdown-box__content box px-4 pt-4 pb-5">
            <div class="text-base font-medium leading-tight mb-4">
              Notifications
            </div>
            <div class="cursor-pointer relative flex items-center">
              <div class="w-10 h-10 flex-none image-fit mr-1">
                <img
                  alt="Topson Messenger Tailwind HTML Admin Template"
                  class="rounded-full"
                  src="https://topson.left4code.com/dist/images/profile-2.jpg"
                />
                <div
                  class="notification-dropdown__content__badge w-3 h-3 absolute right-0 bottom-0 rounded-full border-2"
                ></div>
              </div>
              <div class="ml-2 overflow-hidden">
                <div class="flex items-center">
                  <a href="javascript:;" class="font-medium truncate mr-5"
                    >Tom Cruise</a
                  >
                  <div
                    class="notification-dropdown__content__time text-xs ml-auto whitespace-no-wrap"
                  >
                    01:10 PM
                  </div>
                </div>
                <div
                  class="notification-dropdown__content__text w-full text-xs truncate"
                >
                  There are many variations of passages of Lorem Ipsum
                  available, but the majority have suffered alteration in some
                  form, by injected humour, or randomi
                </div>
              </div>
            </div>
            <div class="cursor-pointer relative flex items-center mt-6">
              <div class="w-10 h-10 flex-none image-fit mr-1">
                <img
                  alt="Topson Messenger Tailwind HTML Admin Template"
                  class="rounded-full"
                  src="https://topson.left4code.com/dist/images/profile-3.jpg"
                />
                <div
                  class="notification-dropdown__content__badge w-3 h-3 absolute right-0 bottom-0 rounded-full border-2"
                ></div>
              </div>
              <div class="ml-2 overflow-hidden">
                <div class="flex items-center">
                  <a href="javascript:;" class="font-medium truncate mr-5"
                    >Keanu Reeves</a
                  >
                  <div
                    class="notification-dropdown__content__time text-xs ml-auto whitespace-no-wrap"
                  >
                    01:10 PM
                  </div>
                </div>
                <div
                  class="notification-dropdown__content__text w-full text-xs truncate"
                >
                  There are many variations of passages of Lorem Ipsum
                  available, but the majority have suffered alteration in some
                  form, by injected humour, or randomi
                </div>
              </div>
            </div>
            <div class="cursor-pointer relative flex items-center mt-6">
              <div class="w-10 h-10 flex-none image-fit mr-1">
                <img
                  alt="Topson Messenger Tailwind HTML Admin Template"
                  class="rounded-full"
                  src="https://topson.left4code.com/dist/images/profile-12.jpg"
                />
                <div
                  class="notification-dropdown__content__badge w-3 h-3 absolute right-0 bottom-0 rounded-full border-2"
                ></div>
              </div>
              <div class="ml-2 overflow-hidden">
                <div class="flex items-center">
                  <a href="javascript:;" class="font-medium truncate mr-5"
                    >Tom Cruise</a
                  >
                  <div
                    class="notification-dropdown__content__time text-xs ml-auto whitespace-no-wrap"
                  >
                    05:09 AM
                  </div>
                </div>
                <div
                  class="notification-dropdown__content__text w-full text-xs truncate"
                >
                  Lorem Ipsum is simply dummy text of the printing and
                  typesetting industry. Lorem Ipsum has been the industry's
                  standard dummy text ever since the 1500
                </div>
              </div>
            </div>
            <div class="cursor-pointer relative flex items-center mt-6">
              <div class="w-10 h-10 flex-none image-fit mr-1">
                <img
                  alt="Topson Messenger Tailwind HTML Admin Template"
                  class="rounded-full"
                  src="https://topson.left4code.com/dist/images/profile-4.jpg"
                />
                <div
                  class="notification-dropdown__content__badge w-3 h-3 absolute right-0 bottom-0 rounded-full border-2"
                ></div>
              </div>
              <div class="ml-2 overflow-hidden">
                <div class="flex items-center">
                  <a href="javascript:;" class="font-medium truncate mr-5"
                    >Arnold Schwarzenegger</a
                  >
                  <div
                    class="notification-dropdown__content__time text-xs ml-auto whitespace-no-wrap"
                  >
                    01:10 PM
                  </div>
                </div>
                <div
                  class="notification-dropdown__content__text w-full text-xs truncate"
                >
                  Contrary to popular belief, Lorem Ipsum is not simply random
                  text. It has roots in a piece of classical Latin literature
                  from 45 BC, making it over 20
                </div>
              </div>
            </div>
            <div class="cursor-pointer relative flex items-center mt-6">
              <div class="w-10 h-10 flex-none image-fit mr-1">
                <img
                  alt="Topson Messenger Tailwind HTML Admin Template"
                  class="rounded-full"
                  src="https://topson.left4code.com/dist/images/profile-10.jpg"
                />
                <div
                  class="notification-dropdown__content__badge w-3 h-3 absolute right-0 bottom-0 rounded-full border-2"
                ></div>
              </div>
              <div class="ml-2 overflow-hidden">
                <div class="flex items-center">
                  <a href="javascript:;" class="font-medium truncate mr-5"
                    >Johnny Depp</a
                  >
                  <div
                    class="notification-dropdown__content__time text-xs ml-auto whitespace-no-wrap"
                  >
                    01:10 PM
                  </div>
                </div>
                <div
                  class="notification-dropdown__content__text w-full text-xs truncate"
                >
                  Lorem Ipsum is simply dummy text of the printing and
                  typesetting industry. Lorem Ipsum has been the industry's
                  standard dummy text ever since the 1500
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- END: Notifications -->
      <!-- BEGIN: Account -->
      <div class="account-dropdown dropdown relative">
        <a
          @click="isProfileSet = !isProfileSet"
          class="h-full dropdown-toggle flex items-center pl-5"
        >
          <div class="hidden md:block ml-3">
            <div class="w-24 truncate font-medium leading-tight">
              Tom Cruise
            </div>
          </div>
        </a>
        <div
          class="dropdown-content dropdown-box absolute w-56 top-0 right-0 z-20"
          :class="isProfileSet ? 'show' : ''"
        >
          <div class="dropdown-box__content box">
            <div class="dropdown-content__footer p-2 border-t">
              <a
                href=""
                class="flex items-center block p-2 transition duration-300 ease-in-out rounded-md"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  stroke-width="1"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  class="feather feather-toggle-right w-4 h-4 mr-2"
                >
                  <rect x="1" y="5" width="22" height="14" rx="7" ry="7"></rect>
                  <circle cx="16" cy="12" r="3"></circle>
                </svg>
                Logout
              </a>
            </div>
          </div>
        </div>
      </div>
      <!-- END: Account -->
    </div>
  </div>
  <div class="side-menu hidden md:block top-0 left-0 fixed w-16 h-screen">
    <div
      class="side-menu__content -intro-x border-r w-full h-full pt-16 flex flex-col justify-center overflow-hidden"
    >
      <a
        class="-intro-x side-menu__content__link relative side-menu__content__link--active tooltip py-5 tooltipstered"
        href="javascript:;"
        data-side="right"
        data-content="chats"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-mail w-5 h-5 mx-auto"
        >
          <path
            d="M4 4h16c1.1 0 2 .9 2 2v12c0 1.1-.9 2-2 2H4c-1.1 0-2-.9-2-2V6c0-1.1.9-2 2-2z"
          ></path>
          <polyline points="22,6 12,13 2,6"></polyline>
        </svg>
      </a>
      <a
        class="-intro-x side-menu__content__link relative tooltip py-5 tooltipstered"
        href="javascript:;"
        data-side="right"
        data-content="groups"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-edit w-5 h-5 mx-auto"
        >
          <path
            d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"
          ></path>
          <path
            d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"
          ></path>
        </svg>
      </a>
      <a
        class="-intro-x side-menu__content__link relative tooltip py-5 tooltipstered"
        href="javascript:;"
        data-side="right"
        data-content="contacts"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-users w-5 h-5 mx-auto"
        >
          <path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"></path>
          <circle cx="9" cy="7" r="4"></circle>
          <path d="M23 21v-2a4 4 0 0 0-3-3.87"></path>
          <path d="M16 3.13a4 4 0 0 1 0 7.75"></path>
        </svg>
      </a>
      <a
        class="-intro-x side-menu__content__link relative tooltip py-5 tooltipstered"
        href="javascript:;"
        data-side="right"
        data-content="profile"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-user w-5 h-5 mx-auto"
        >
          <path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"></path>
          <circle cx="12" cy="7" r="4"></circle>
        </svg>
      </a>
      <a
        class="-intro-x side-menu__content__link relative tooltip py-5 tooltipstered"
        href="login.html"
        data-side="right"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-lock w-5 h-5 mx-auto"
        >
          <rect x="3" y="11" width="18" height="11" rx="2" ry="2"></rect>
          <path d="M7 11V7a5 5 0 0 1 10 0v4"></path>
        </svg>
      </a>
      <a
        class="-intro-x side-menu__content__link relative tooltip py-5 tooltipstered"
        href="register.html"
        data-side="right"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-user-plus w-5 h-5 mx-auto"
        >
          <path d="M16 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"></path>
          <circle cx="8.5" cy="7" r="4"></circle>
          <line x1="20" y1="8" x2="20" y2="14"></line>
          <line x1="23" y1="11" x2="17" y2="11"></line>
        </svg>
      </a>
      <a
        class="-intro-x side-menu__content__link relative tooltip py-5 tooltipstered"
        href="settings.html"
        data-side="right"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="1"
          stroke-linecap="round"
          stroke-linejoin="round"
          class="feather feather-settings w-5 h-5 mx-auto"
        >
          <circle cx="12" cy="12" r="3"></circle>
          <path
            d="M19.4 15a1.65 1.65 0 0 0 .33 1.82l.06.06a2 2 0 0 1 0 2.83 2 2 0 0 1-2.83 0l-.06-.06a1.65 1.65 0 0 0-1.82-.33 1.65 1.65 0 0 0-1 1.51V21a2 2 0 0 1-2 2 2 2 0 0 1-2-2v-.09A1.65 1.65 0 0 0 9 19.4a1.65 1.65 0 0 0-1.82.33l-.06.06a2 2 0 0 1-2.83 0 2 2 0 0 1 0-2.83l.06-.06a1.65 1.65 0 0 0 .33-1.82 1.65 1.65 0 0 0-1.51-1H3a2 2 0 0 1-2-2 2 2 0 0 1 2-2h.09A1.65 1.65 0 0 0 4.6 9a1.65 1.65 0 0 0-.33-1.82l-.06-.06a2 2 0 0 1 0-2.83 2 2 0 0 1 2.83 0l.06.06a1.65 1.65 0 0 0 1.82.33H9a1.65 1.65 0 0 0 1-1.51V3a2 2 0 0 1 2-2 2 2 0 0 1 2 2v.09a1.65 1.65 0 0 0 1 1.51 1.65 1.65 0 0 0 1.82-.33l.06-.06a2 2 0 0 1 2.83 0 2 2 0 0 1 0 2.83l-.06.06a1.65 1.65 0 0 0-.33 1.82V9a1.65 1.65 0 0 0 1.51 1H21a2 2 0 0 1 2 2 2 2 0 0 1-2 2h-.09a1.65 1.65 0 0 0-1.51 1z"
          ></path>
        </svg>
      </a>
    </div>
  </div>
  <!-- END: Top Bar -->
  <slot></slot>
</template>

<script>
export default {
  name: "AuthLayout",
  data() {
    return {
      isProfileSet: false
    };
  }
};
</script>
