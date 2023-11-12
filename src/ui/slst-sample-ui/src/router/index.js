import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    redirect: { name: "auth" },
  },
  {
    path: "/auth",
    name: "auth",
    component: () => import("../components/AuthComponent.vue"),
  },
  {
    path: "/login",
    name: "login",
    component: () => import("../components/LoginComponent.vue"),
  },
  {
    path: "/success",
    name: "success",
    component: () => import("../components/SuccessComponent.vue"),
  },
  {
    path: "/img",
    name: "img",
    component: () => import("../components/ImgComponent.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
