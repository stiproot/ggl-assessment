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
